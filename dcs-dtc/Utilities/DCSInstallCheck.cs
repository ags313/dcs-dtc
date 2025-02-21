using System.Runtime.InteropServices;

namespace DTC.Utilities
{
    internal static class DCSInstallCheck
    {
        [DllImport("shell32.dll", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        static extern string SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, IntPtr hToken = default);

        static Guid SavedGamesFolderGuid = new Guid("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4");

        public static string MAIN_LUA_FILE = "DCSDTC.lua";

        private static List<string> FindDcsFolders(string savedGamesPath)
        {
            var result = new List<string>();
            foreach (var directory in Directory.EnumerateDirectories(savedGamesPath))
            {
                if (directory.ToUpper().Contains("DCS.") || directory.ToUpper().EndsWith("DCS"))
                {
                    var options = directory + "\\config\\options.lua";
                    if (!File.Exists(options))
                    {
                        // by-name match found, but it doesn't look like a DCS game folder, skipping!
                        continue;
                    }

                    if (Directory.Exists(directory + "\\metashaders2.stub"))
                    {
                        // this is a dedicated server folder, skipping!
                        continue;
                    }
                    if (File.Exists((directory + "\\donttouch.txt")))
                    {
                        // looks like DCS, but maybe skip
                        continue;
                    }
                    
                    result.Add(directory);
                }
            }

            return result;
        }
        
        public static bool Check()
        {
            if (Settings.SkipDCSInstallCheck) return true;

            var savedGamesPath = SHGetKnownFolderPath(SavedGamesFolderGuid, 0);
            if (string.IsNullOrEmpty(savedGamesPath))
            {
                DTCMessageBox.ShowError("Saved Games folder not found. Cannot continue.");
                return false;
            }

            var paths = FindDcsFolders(savedGamesPath);

            if (paths.Count == 0)
            {
                DTCMessageBox.ShowError("DCS or DCS.openbeta folder not found under Saved Games.\n\nPlease run DCS once, then exit DCS and try again.");
                return false;
            }

            var atLeastOne = false;
            foreach (var path in paths)
            {
                atLeastOne |= CheckAndInstall(path);
            }
            
            if (!atLeastOne)
            {
                DTCMessageBox.ShowError("Cannot continue since DTC is not installed on either DCS or DCS.openbeta folder under Saved Games.");
                return false;
            }

            return true;
        }

        private static bool CheckAndInstall(string path)
        {
            var userAsked = false;
            var dtcLuaInstalled = false;
            var dtcLuaUpdated = false;

            var scriptsFolder = Path.Combine(path, "Scripts");
            if (!Directory.Exists(scriptsFolder))
            {
                if (AskUserToInstall(path) == false) return false;
                userAsked = true;
                Directory.CreateDirectory(scriptsFolder);
            }

            var exportLuaPath = Path.Combine(scriptsFolder, "Export.lua");
            if (!File.Exists(exportLuaPath))
            {
                if (!userAsked && AskUserToInstall(path) == false) return false;
                userAsked = true;
                File.WriteAllText(exportLuaPath, "");
            }

            var exportLuaContent = File.ReadAllText(exportLuaPath);
            if (!exportLuaContent.Contains("local DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/" + MAIN_LUA_FILE + "')"))
            {
                if (!exportLuaContent.Contains(MAIN_LUA_FILE))
                {
                    if (!userAsked && AskUserToInstall(path) == false) return false;
                    dtcLuaInstalled = true;
                    exportLuaContent += "\n\nlocal DCSDTClfs=require('lfs'); dofile(DCSDTClfs.writedir()..'Scripts/" + MAIN_LUA_FILE + "')";
                    File.WriteAllText(exportLuaPath, exportLuaContent);
                }
                else
                {
                    DTCMessageBox.ShowError($"Incorrect DCSDTC.lua install on {exportLuaPath}.\n\nPlease delete the incorrect line, run DTC again, and it will be installed automatically.");
                    return false;
                }
            }

            var dcsDtcLuaPath = Path.Combine(scriptsFolder, MAIN_LUA_FILE);
            var originalDcsDtcLuaPath = Path.Combine(FileStorage.GetCurrentFolder(), "DCS", MAIN_LUA_FILE);
            if (!File.Exists(dcsDtcLuaPath))
            {
                dtcLuaInstalled = true;
                File.Copy(originalDcsDtcLuaPath, dcsDtcLuaPath);
            }

            var dcsDtcLuaContent = File.ReadAllText(dcsDtcLuaPath);
            var originalDcsDtcLuaContent = File.ReadAllText(originalDcsDtcLuaPath);

            if (dcsDtcLuaContent != originalDcsDtcLuaContent)
            {
                dtcLuaUpdated = true;
                File.Copy(originalDcsDtcLuaPath, dcsDtcLuaPath, true);
            }

            var folderChanged1 = CopyDCSDTCFolder("DCSDTC", scriptsFolder);
            var folderChanged2 = CopyDCSDTCFolder("Hooks", scriptsFolder);

            if (dtcLuaInstalled || dtcLuaUpdated || folderChanged1 || folderChanged2)
            {
                var txt = dtcLuaInstalled ? "installed" : "updated";
                DTCMessageBox.ShowInfo($"DCSDTC.lua was {txt} in {path}.\n\nIf DCS is running, please restart DCS.");
            }

            return true;
        }

        private static bool CopyDCSDTCFolder(string folderToCopy, string scriptsFolder)
        {
            var localFolderPath = Path.Combine(FileStorage.GetCurrentFolder(), "DCS", folderToCopy);
            var remoteFolderPath = Path.Combine(scriptsFolder, folderToCopy);
            return CompareAndCopyFolder(localFolderPath, remoteFolderPath);
        }

        private static bool CompareAndCopyFolder(string localFolderPath, string remoteFolderPath)
        {
            var changed = false;

            if (!Directory.Exists(remoteFolderPath))
            {
                Directory.CreateDirectory(remoteFolderPath);
            }

            foreach (var localFilePath in Directory.GetFiles(localFolderPath))
            {
                if (CompareAndCopyFile(localFilePath, remoteFolderPath))
                {
                    changed = true;
                }
            }

            foreach (var localSubFolderPath in Directory.GetDirectories(localFolderPath))
            {
                var folderName = Path.GetFileName(localSubFolderPath);
                var remoteSubFolderPath = Path.Combine(remoteFolderPath, folderName);
                if (CompareAndCopyFolder(localSubFolderPath, remoteSubFolderPath))
                {
                    changed = true;
                }
            }

            return changed;
        }

        private static bool CompareAndCopyFile(string localFilePath, string remoteFolderPath)
        {
            var fileName = Path.GetFileName(localFilePath);
            var remoteFilePath = Path.Combine(remoteFolderPath, fileName);

            var localFileContent = File.ReadAllText(localFilePath);
            localFileContent = CheckSpecialFileContents(fileName, localFileContent);

            if (!File.Exists(remoteFilePath))
            {
                File.WriteAllText(remoteFilePath, localFileContent);
                return true;
            }

            var remoteFileContent = File.ReadAllText(remoteFilePath);

            if (localFileContent != remoteFileContent)
            {
                File.WriteAllText(remoteFilePath, localFileContent);
                return true;
            }

            return false;
        }

        private static string CheckSpecialFileContents(string fileName, string localFileContent)
        {
            if (fileName == "wptCapture.lua")
            {
                localFileContent = localFileContent.Replace("Ctrl+Shift+d", Settings.CaptureDialogShortcut);
            }

            if (fileName == "kneeboard.lua")
            {
                localFileContent = localFileContent.Replace("Ctrl+Shift+k", Settings.KneeboardDialogShortcut);
            }

            return localFileContent;
        }

        private static bool AskUserToInstall(string path)
        {
            return DTCMessageBox.ShowQuestion($"DTC is not installed at {path}. Do you want to install it?");
        }
    }
}