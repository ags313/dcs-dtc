function DTC_Log(str)
    DTC_logFile:write(str .. "\n");
    DTC_logFile:flush();
end

function DTC_DCSLogInfo(str)
    log.write("DCS-DTC", log.INFO, str)
end

function DTC_DCSLogError(str)
    log.write("DCS-DTC", log.ERROR, str)
end

function DTC_ParseDisplay(indicator_id) -- Thanks to [FSF]Ian code
    local t = {}
    local li = list_indication(indicator_id)
    local m = li:gmatch("-----------------------------------------\n([^\n]+)\n([^\n]*)\n")
    while true do
        local name, value = m()
        if not name then
            break
        end
        t[name] = value
    end
    return t
end

function DTC_LinesToList(s)
    local i = 1
    local list = {}
    s:gsub("(.-)\n", function(s)
        list[i] = s; i = i + 1
    end)
    return list
end

function DTC_FlattenTable(table)
    local flattened = {}
    for key, value in pairs(table) do
        if type(value) == "table" then
            local nested_flattened = DTC_FlattenTable(value)
            for nested_key, nested_value in pairs(nested_flattened) do
                flattened[key .. "." .. nested_key] = nested_value
            end
        else
            flattened[key] = value
        end
    end
    return flattened
end

function DTC_GetDisplay2(id)
    local SEP = "-----------------------------------------"
    local s = list_indication(id)
    local err = false
    if not s then
        return {}
    end
    local cur_table = {}
    local tables = { cur_table }
    local strlist = DTC_LinesToList(s)
    if #strlist == 0 then
        return {}
    end
    local i = 1
    repeat
        if strlist[i] == SEP then
            i = i + 1
            local name = strlist[i]
            i = i + 1
            local value = {}
            cur_table[name] = value
            while i <= #strlist and strlist[i] ~= SEP and strlist[i] ~= "}" and strlist[i] ~= "children are {" do
                value[#value + 1] = strlist[i]
                i = i + 1
            end
            if strlist[i] == "children are {" then
                new_table = {}
                tables[#tables + 1] = new_table
                value[#value + 1] = new_table
                cur_table = new_table
                i = i + 1
            end
        elseif strlist[i] == "}" then
            tables[#tables] = nil
            cur_table = tables[#tables]
            i = i + 1
        else
            err = true
            DTC_DCSLogError("Unexpected output: " .. strlist[i])
            i = i + 1
        end
    until i > #strlist
    if err then
        DTC_DCSLogError(s)
    end
    return DTC_FlattenTable(cur_table)
end

function DTC_TrimString(str)
    return str:gsub("^%s*(.-)%s*$", "%1")
end

function DTC_SplitString(str, delimiter)
    local result = {}
    for token in string.gmatch(str, "[^" .. delimiter .. "]+") do
        table.insert(result, token)
    end
    return result
end

function DTC_GetDisplay(id)
    local SEP = "-----------------------------------------"
    local s = list_indication(id)
    local err = false
    if not s then
        return {}
    end
    local cur_table = {}
    local tables = { cur_table }
    local strlist = DTC_LinesToList(s)
    if #strlist == 0 then
        return {}
    end
    local i = 1
    repeat
        if strlist[i] == SEP then
            i = i + 1
            while i <= #strlist and DTC_TrimString(strlist[i]) == "" do
                i = i + 1
            end
            local name = DTC_TrimString(strlist[i])
            i = i + 1
            local value = {}
            cur_table[name] = value
            while i <= #strlist and strlist[i] ~= SEP and strlist[i] ~= "}" and strlist[i] ~= "children are {" do
                value[#value + 1] = DTC_TrimString(strlist[i])
                i = i + 1
            end
            if strlist[i] == "children are {" then
                new_table = {}
                tables[#tables + 1] = new_table
                value[#value + 1] = new_table
                cur_table = new_table
                i = i + 1
            end
        elseif strlist[i] == "}" then
            tables[#tables] = nil
            cur_table = tables[#tables]
            i = i + 1
        else
            err = true
            DTC_DCSLogError("Unexpected output: " .. strlist[i])
            i = i + 1
        end
    until i > #strlist
    if err then
        DTC_DCSLogError(s)
    end
    return DTC_FlattenTable(cur_table)
end

function DTC_GetPlayerAircraftType()
    local data = LoGetSelfData();
    if data then
        local model = data["Name"];
        if model == "F-16C_50" then return "F16C" end
        if model == "FA-18C_hornet" then return "FA18C" end
        if model == "F-15ESE" then return "F15E" end
        return model;
    end
    return "Unknown"
end

function DTC_SerializeDisplay(val, name, skipnewlines, depth)
    skipnewlines = skipnewlines or false
    depth = depth or 0

    local tmp = string.rep(" ", depth)

    if name then tmp = tmp .. name .. " = " end

    if type(val) == "table" then
        tmp = tmp .. "{" .. (not skipnewlines and "\n" or "")

        for k, v in pairs(val) do
            tmp = tmp .. DTC_SerializeDisplay(v, k, skipnewlines, depth + 1) .. "," .. (not skipnewlines and "\n" or "")
        end

        tmp = tmp .. string.rep(" ", depth) .. "}"
    elseif type(val) == "number" then
        tmp = tmp .. tostring(val)
    elseif type(val) == "string" then
        tmp = tmp .. string.format("%q", val)
    elseif type(val) == "boolean" then
        tmp = tmp .. (val and "true" or "false")
    else
        tmp = tmp .. "\"[inserializeable datatype:" .. type(val) .. "]\""
    end

    return tmp
end

function DTC_DebugDisplay(display)
    local tbl = DTC_SerializeDisplay(display);
    DTC_Log(tbl);
end
