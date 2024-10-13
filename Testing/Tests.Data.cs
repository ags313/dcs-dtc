namespace Testing
{

    class Data
    {
        public const String plan1 = """
                                    Flight Plan
                                    #	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT	Leg Fuel
                                    1	TRN		FLEX	N 36°18.617' W 115°02.367'		4000
                                    2	TRN		DREAM	N 37°10.333' W 114°59.534'		25000
                                    3	TRN		GRN 26	N 37°46.056' W 115°18.963'		25000
                                    4	TRN		BLUE M	N 37°36.361' W 116°43.586'		25000
                                    5	TRN		MT IRISH	N 37°38.500' W 115°24.000'		25000
                                    6	TRN		ALAMO	N 37°17.565' W 115°07.730'		25000
                                    7	TRN		HAYFORD PK	N 36°39.878' W 115°09.615'		12000
                                    8	TRN		APEX	N 36°21.583' W 114°54.333'		4500
                                    9	LDG		KLSV.21R	N 36°14.845' W 115°01.457'	1841
                                    10
                                    11
                                    12
                                    13	OBJ		4808A.1	N 37°28.000' W 116°00.050'
                                    14	OBJ		4808A.3	N 37°28.000' W 115°35.050'
                                    15	OBJ		4808A.5	N 37°06.000' W 115°35.050'
                                    16	OBJ		4808A.7	N 37°06.000' W 116°00.050'
                                    17	OBJ		4808A.9	N 37°28.000' W 116°00.050'
                                    18
                                    19	RVIP		Amoco.IP	N 37°41.000' W 114°30.000'
                                    20
                                    21
                                    """;

        public const String problematic1 = """
                                           Flight Plan
                                           #	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT	Leg Fuel
                                           1	TRN		FLEX	N 36°18.617' W 115°02.367'
                                           2	TRN		DREAM	N 37°10.333' W 114°59.534'
                                           3	TRN		ELGIN N PT	N 37°21.000' W 114°32.000'
                                           4	TRN		ELGIN S PT	N 36°53.000' W 114°40.000'
                                           5	TRN		ACTON	N 36°44.517' W 114°36.450'
                                           6	LDG		APEX	N 36°21.583' W 114°54.333'
                                           7			KLSV.21R	N 36°14.845' W 115°01.457'	1841
                                           8	OBJ
                                           9	OBJ		Elgin.1	N 37°17.000' W 114°50.720'
                                           10	OBJ		Elgin.2	N 37°27.900' W 114°34.710'
                                           11	OBJ		Elgin.3	N 37°27.020' W 114°00.470'
                                           12	OBJ		Elgin.4	N 36°43.000' W 114°36.050'
                                           13	OBJ		Elgin.5	N 36°43.010' W 114°50.720'
                                           14			Elgin.6	N 37°17.000' W 114°50.720'
                                           15	RVIP
                                           16			Amoco.IP	N 37°41.000' W 114°30.000'
                                           17
                                           18
                                           """;

        public const String viperPlanWithNotes = """
                                                 476th Virtual Fighter Group - Powered by vBulletin
                                                 Log Out
                                                 Settings
                                                 My Profile
                                                 Notifications
                                                 Welcome, Avantar
                                                 Home
                                                 Forum
                                                 Recruiting
                                                 Downloads
                                                 Awards
                                                 OPS
                                                 CreateViewsToolsPoints
                                                 NTTR
                                                 MI
                                                 Flight log
                                                 Calendar
                                                 What's New?
                                                 15:40:13 ZULU

                                                 476th vFG
                                                 >
                                                 Mission Data Card
                                                 TR-1001 - Viper 1
                                                 
                                                   Print
                                                 Mission Data Card
                                                 Callsign: Viper 1Mission # TR-1001Mission: TrainingPackage # 476103
                                                 Flight
                                                 Pilot	Crew	TN	TCN	IFF M1	IFF M3	SRCH	LASER
                                                 -1		/////	04211	29Y	31	5651	LO	1511
                                                 -2		/////	04212	92Y	31	5652	HI	1512
                                                 Radios
                                                 Radio	Usage
                                                 PRI	1-3-4-10-13
                                                 AUX	40.4

                                                 Package
                                                 Callsign	A/C	# Ships	Mission #	Time	Comms	TN -1	TCN	Task
                                                 Viper 1	F-16C	2	TR-1001	19:00	40.4	4211	29Y	ACT-1 | CAL A.B/COY/REV 100-UNL | Roman/Coco
                                                 Wolf 1	F-16C	2	TR-1005	19:00	69.6	011	44Y	Aggrs Support/Florence-Lurch

                                                 Support
                                                 Instance	Type	Callsign	Comms	TCN	Location	Alt
                                                 Tanker	KC-135	TEXACO	342.15	76Y	AMOCO	270

                                                 Loadout/Config
                                                 Loadout	Config	Fuel
                                                 A/A	5Ax1Wx2	Gross Wt	34384	TO	11800
                                                 A/G		Drag Index		TGT
                                                 Pods		MIN AGL		Joker	4500
                                                 Remarks	120C, 9X, NO GUN	MIN MSL	10000	Bingo	2500
                                                 MAX MSL	40000	Tanker Onload	AS REQ
                                                 Target
                                                 Description	Coords	Elevation
                                                 Primary
                                                 Alternate
                                                 DPI-1
                                                 DPI-2
                                                 DPI-3
                                                 DPI-4
                                                 ATIS/WX
                                                 POSTED AT BRIEF

                                                 Airbase
                                                 Airbase	TCN	UHF	VHF	ATIS	RWY	Elev	ILS
                                                 DEP	Nellis	12X	327.1	132.65	270.1	21R	1857
                                                 ARR	Nellis	12X	327.1	132.65	270.1	21R	1857
                                                 ALT	Creech	87X	360.7	118.4	122.5	26	3127
                                                 Departure/Arrival
                                                 Departure	FLEX NORTH	Recovery	ALAMO
                                                 Rotation	165-MIL	Refusal	100	Rejoin	Straight Ahead
                                                 Flight Plan
                                                 #	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT	Leg Fuel
                                                 1	TRN		DREAM	N 37°10.333' W 114°59.534'
                                                 2	OBJ		MAINE N	N 37°48.000' W 114°55.000'
                                                 3	OBJ		BLUE M	N 37°36.361' W 116°43.586'
                                                 4	TRN		MT IRISH	N 37°38.500' W 115°24.000'
                                                 5	IAF		ALAMO	N 37°17.565' W 115°07.730'
                                                 6	TRN		HAYFORD PK	N 36°39.878' W 115°09.615'
                                                 7	TRN		APEX	N 36°21.583' W 114°54.333'
                                                 8	LDG		KLSV.21R	N 36°14.845' W 115°01.457'	1841
                                                 9
                                                 10			4808A.1	N 37°28.000' W 116°00.050'
                                                 11			4808A.3	N 37°28.000' W 115°35.050'
                                                 12			4808A.5	N 37°06.000' W 115°35.050'
                                                 13			4808A.7	N 37°06.000' W 116°00.050'
                                                 14			4808A.9	N 37°28.000' W 116°00.050'
                                                 15
                                                 16	RVIP		Amoco.IP	N 37°41.000' W 114°30.000'
                                                 17
                                                 18
                                                 19
                                                 20
                                                 21
                                                 22
                                                 23
                                                 24
                                                 25
                                                 26
                                                 27
                                                 28
                                                 29
                                                 30
                                                 Notes

                                                 Mission Objectives
                                                 1. Introduce BVR concepts and terms.
                                                 2. Introduce combat air patrol (CAP), and CAP contracts.
                                                 3. Introduce launch and leave (L&L) gameplan and the active-short timeline.
                                                 4. Introduce/practice below specific mission tasks.


                                                 Specific Mission Tasks
                                                 1. FENCE check/armament switchology
                                                 2. G-awareness/G-exercise
                                                 3. * CAP
                                                 4. * Targeting (picture, directive, AOR)
                                                 5. * Sorting (owner, sharer)
                                                 6. * Shot doctrine
                                                 7. * SKATE flow
                                                 8. * SHORT-SKATE flow and recommit
                                                 9. Battle damage check
                                                 10. RTB procedures

                                                 All times are GMT +1. The time now is 16:40.
                                                 Powered by vBulletin® Version 4.2.5
                                                 Copyright © 2023 vBulletin Solutions Inc. All rights reserved.

                                                 Visitor Links
                                                 About Us
                                                 Recruiting
                                                 Downloads
                                                 Contact Us
                                                 Member Links
                                                 My User CP
                                                 My Inbox (0)
                                                 Flight Log
                                                 OPS Board
                                                 Like our website?
                                                 You can help us by donating to cover our costs.

                                                 Many sincere thanks!


                                                 Donate with PayPal button
                                                 Search
                                                 Prześlij
                                                 Advanced Search
                                                 Follow us
                                                 Twitter Twitter youtube


                                                 """;

        public const String hornetFail = """
                                         1	TO		CRAIG	N 36°15.250' W 115°08.267'		5500	350
                                         2	TRN		FYTTR	N 36°21.440' W 115°41.470'		14000	350
                                         3	TRN		NIXON	N 36°32.017' W 115°32.250'		14000	350
                                         4	TRN		SARAH	N 36°36.450' W 115°18.033'		15000	350
                                         5	TRN		ELGIN N PT	N 37°21.000' W 114°32.000'		15000	350
                                         6	TRN		ELGIN S PT	N 36°53.000' W 114°40.000'		15000	350
                                         7	IAF		ACTON	N 36°44.517' W 114°36.450'		8000	350
                                         8	FAF		APEX	N 36°21.583' W 114°54.333'		450	250
                                         9	LDG		NELLIS AFB	N 36°14.113' W 115°01.980'		1842
                                         """;

        public const String hornetFail2 = """
                                          Flight Plan
                                          #	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT	Leg Fuel
                                          1	TRN	MINTT	MINTT	N 36°42.733' W 115°06.283'		FL180	.81
                                          2	TRN	DREAM	DREAM	N 37°10.333' W 114°59.534'		FL240	.81
                                          3	TRN	MT IRISH	MT IRISH	N 37°38.500' W 115°24.000'		FL240	.81
                                          4	IP	GRN E	GRN E	N 37°40.632' W 115°57.056'		FL240	.81
                                          5	TGT	R74B/C Centr		11SNB7237453149	5500
                                          6	TRN	MT IRISH	MT IRISH	N 37°38.500' W 115°24.000'			.81
                                          7	TRN	ARCOE	ARCOE	N 36°44.267' W 114°55.017'		15000A	350
                                          8	TRN	APEX	APEX	N 36°21.583' W 114°54.333'		4500	350
                                          9		ELVIS	ELVIS	N 37°15.000' W 115°45.000'
                                          10
                                          11
                                          12
                                          13
                                          14
                                          15
                                          16
                                          17
                                          18
                                          19
                                          20
                                          21
                                          22
                                          23
                                          24
                                          25
                                          26
                                          27
                                          28
                                          29
                                          30
                                          """;
        public const String ViperFirefoxOK = "\r\n476th Virtual Fighter Group - Powered by vBulletin\r\n\r\n    Log Out\r\n    Settings\r\n    My Profile\r\n    Notifications\r\n    Welcome, Avantar\r\n\r\n    Home\r\n    Forum\r\n    Recruiting\r\n    Downloads\r\n    Awards\r\n    OPS\r\n        Create\r\n        Views\r\n        Tools\r\n        Points\r\n    NTTR\r\n    MI\r\n    Flight log\r\n    Calendar\r\n    What's New?\r\n    09:21:11 ZULU \r\n\r\n476th vFG\r\n>\r\nMission Data Card\r\n\r\nMission Data Card\r\nCallsign:\r\nMission #\r\nMission:\r\nPackage #\r\nFlight\r\n\tPilot \tCrew \tTN \tTCN \tIFF M1 \tIFF M3 \tSRCH \tLASER\r\n-1 \t\t\t\t\t\t\t\t\r\n-2 \t\t\t\t\t\t\t\r\n-3 \t\t\t\t\t\t\t\r\n-4 \t\t\t\t\t\t\t\r\n\r\nRadios\r\nRadio \tUsage\r\nPRI \t1-3-4-10\r\nAUX \t69.6F2\r\n\t\r\n\t\r\n\t\r\n\r\nPackage\r\nCallsign \tA/C \t# Ships \tMission # \tTime \tComms \tTN \tTCN \tTask\r\n\r\nSupport\r\nInstance \tType \tCallsign \tComms \tTCN \tLocation \tAlt\r\nTanker \tKC-135 \tTEXACO 3 \t342.15 \t76Y \tAMOCO \tFL270\r\nTanker \tKC-135 \tTEXACO 5 \t348.5 \t55Y \tAMOCO \t18000\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t\r\n\t\t\t\t\t\t\r\n\r\nLoadout/Config\r\nLoadout \tConfig \tFuel\r\nA/A \t2Ax1Wx1 \tGross Wt \t30217 \tTO \t8500\r\nA/G \t/// \tDrag Index \t\tTGT \t\r\nPods \tTCTS-50 \tMIN AGL \t\tJoker \t3500\r\nRemarks \t120B, CAIM-9M, NO GUN, 60 C/F, Belly Tank, CAT 1 \tMIN MSL \t\tBingo \t2500\r\n\tMAX MSL \t\tTanker Onload \tMAX\r\n\r\nTarget\r\n\tDescription \tCoords \tElevation\r\nPrimary \t\t\t\r\nAlternate \t\t\t\r\nDPI-1 \t\t\t\r\nDPI-2 \t\t\t\r\nDPI-3 \t\t\t\r\nDPI-4 \t\t\t\r\n\r\nATIS/WX\r\nWx D: KLSV 012000Z AUTO 01007KT 10SM FEW060 30/11 A2975\r\n\r\nAirbase\r\n\tAirbase \tTCN \tUHF \tVHF \tATIS \tRWY \tElev \tILS\r\nDEP \tNellis \t12X \t327.1 \t132.65 \t270.1 \t21R \t1857 \t\r\nARR \tNellis \t12X \t327.1 \t132.65 \t270.1 \t21L \t1854 \t109.1\r\nALT \tCreech \t87X \t360.7 \t118.4 \t122.5 \t26 \t3127 \t\r\n\r\nDeparture/Arrival\r\nDeparture \tFLEX NORTH \tRecovery \tACTON\r\nRotation \tMIL-153 \tRefusal \t/// \tRejoin \tStraight Ahead\r\n\r\nFlight Plan\r\n# \tType \tName \tFix/Point \tLocation \tElev \tAlt \tSPD \tETE/TOT \tLeg Fuel\r\n1 \tTRN \t\tFLEX \tN 36°18.617' W 115°02.367' \t\t\t\t\t\r\n2 \tTRN \t\tDREAM \tN 37°10.333' W 114°59.534' \t\t\t\t\t\r\n3 \t\t\t\t\t\t\t\t\t\r\n4 \tRVIP \t\tAmoco.IP \tN 37°41.000' W 114°30.000' \t\t\t\t\t\r\n5 \t\t\t\t\t\t\t\t\t\r\n6 \tTRN \t\tACTON \tN 36°44.517' W 114°36.450' \t\t\t\t\t\r\n7 \tLDG \t\tAPEX \tN 36°21.583' W 114°54.333' \t\t\t\t\t\r\n8 \tLDG \t\tKLSV.21L \tN 36°14.728' W 115°01.314' \t1853 \t\t\t\t\r\n9 \t\t\t\t\t\t\t\t\t\r\n10 \tOBJ \t\tElgin.1 \tN 37°17.000' W 114°50.720' \t\t\t\t\t\r\n11 \tOBJ \t\tElgin.2 \tN 37°27.900' W 114°34.710' \t\t\t\t\t\r\n12 \tOBJ \t\tElgin.3 \tN 37°27.020' W 114°00.470' \t\t\t\t\t\r\n13 \tOBJ \t\tElgin.4 \tN 36°43.000' W 114°36.050' \t\t\t\t\t\r\n14 \tOBJ \t\tElgin.5 \tN 36°43.010' W 114°50.720' \t\t\t\t\t\r\n15 \tOBJ \t\tElgin.6 \tN 37°17.000' W 114°50.720' \t\t\t\t\t\r\n16 \t\t\t\t\t\t\t\t\t\r\n17 \t\t\t\t\t\t\t\t\t\r\n18 \t\t\t\t\t\t\t\t\t\r\n19 \t\t\t\t\t\t\t\t\t\r\n20 \t\t\t\t\t\t\t\t\t\r\n21 \t\t\t\t\t\t\t\t\t\r\n22 \t\t\t\t\t\t\t\t\t\r\n23 \t\t\t\t\t\t\t\t\t\r\n24 \t\t\t\t\t\t\t\t\t\r\n25 \t\t\t\t\t\t\t\t\t\r\n26 \t\t\t\t\t\t\t\t\t\r\n27 \t\t\t\t\t\t\t\t\t\r\n28 \t\t\t\t\t\t\t\t\t\r\n29 \t\t\t\t\t\t\t\t\t\r\n30 \t\t\t\t\t\t\t\t\t\r\n\r\nNotes\r\n\r\n    All times are GMT +1. The time now is 10:20.\r\n    Powered by vBulletin® Version 4.2.5\r\n    Copyright © 2024 vBulletin Solutions Inc. All rights reserved. \r\n\r\n\r\n\r\nVisitor Links\r\n\r\n    About Us\r\n    Recruiting\r\n    Downloads\r\n    Contact Us\r\n\r\nMember Links\r\n\r\n    My User CP\r\n    My Inbox (0)\r\n    Flight Log\r\n    OPS Board\r\n\r\nLike our website?\r\n\r\nYou can help us by donating to cover our costs.\r\n\r\nMany sincere thanks!\r\n\r\nSearch\r\nAdvanced Search\r\nFollow us\r\n\r\nTwitter Twitter youtube\r\n\r\n";


        public const String karma20240106 = """
                                            Mission Data Card
                                            Callsign: Demon 2Mission # TR-0103Mission: TrainingPackage # 476766
                                            Flight
                                            Pilot	Crew	TN	TCN	IFF M1	IFF M3	SRCH	LASER
                                            -1	Karma	/////	21	42Y	12	5171	HI	1521
                                            -2	Odin	/////	22	105Y	12	5172	LO	1522
                                            Radios
                                            Radio	Usage
                                            PRI	20 - 1 - 3 - 14 - 3- 16 - 1
                                            AUX	18

                                            Package
                                            Callsign	A/C	# Ships	Mission #	Time	Comms	TN -1	TCN	Task
                                            Demon 2	F/A-18C	2	TR-0103	11:30		021	42Y	Odin / Karma range work

                                            Support
                                            Instance	Type	Callsign	Comms	TCN	Location	Alt
                                            Tanker	S-3B	Shell 61	399.950		Overhead mother	FL70
                                            Tanker	KC-135MPRS	Shell 11	273.525	31Y	Mirage	FL240

                                            Loadout/Config
                                            Loadout	Config	Fuel
                                            A/A	1WX2	Gross Wt	41774	TO	15293
                                            A/G	3G12	Drag Index	94.50	TGT	
                                            Pods	ATFLIR	MIN AGL		Joker	4500
                                            Remarks	0 GUN, 0C/120F, AIS, JHMCS, Set Laser code, DU	MIN MSL		Bingo	3500
                                            MAX MSL		Tanker Onload	
                                            Target
                                            Description	Coords	Elevation
                                            Primary			
                                            Alternate			
                                            DPI-1			
                                            DPI-2			
                                            DPI-3			
                                            DPI-4			
                                            ATIS/WX
                                            B - PGUA 012359Z AUTO 08007KT 10SM CLR 27/23 A2997

                                            Airbase
                                            Airbase	TCN	UHF	VHF	ATIS	RWY	Elev	ILS
                                            DEP	CVN-75 Harry S. Truman	75X	375.95				0	15
                                            ARR	CVN-75 Harry S. Truman	75X	375.95				0	15
                                            ALT	Andersen AFB	54X	233.7	121.7		06R	549	110.1
                                            Departure/Arrival
                                            Departure	CASE I	Recovery	CASE I
                                            Rotation		Refusal		Rejoin	Straight Ahead
                                            Flight Plan
                                            #	Type	Name	Fix/Point	Location	Elev	Alt	SPD	ETE/TOT	Leg Fuel
                                            1	TO		CV	N 14º11.144' E 146º48.690'					
                                            2	TRN		MIRAGE.EN	N 15°40.00000' E 145°45.00					
                                            3	IP		MIRAGE.IP	N 16°00.00000' E 146°15.0000					
                                            4	TGT		FDM	N 16°01.03333' E 146°03.5166					
                                            5	TRN		MIRAGE.EX	N 15°40.00000' E 145°59.00					
                                            6									
                                            7									
                                            8									
                                            9									
                                            10	RVCP		MIRAGE.IP	N 16°00.00000' E 146°15.0000					
                                            11	RVCP		MIRAGE.CP	N 16°45.00000' E 146°10.0000					
                                            12									
                                            13									
                                            14									
                                            15									
                                            16									
                                            17									
                                            18									
                                            19									
                                            20									
                                            21									
                                            22									
                                            23									
                                            24									
                                            25									
                                            26									
                                            27									
                                            28									
                                            29									
                                            30		B/E		N 13º35.04' E 144º55.80'					
                                            Notes

                                            CVN-75
                                            TCN: 75X
                                            ICLS: 15
                                            CV TWR: BTN 1
                                            CV MARSHAL: BTN 16
                                            SQ COMMON: BTN 20
                                            N 14º11.144' E 146º48.690'
                                            Event 1: 06:50:00L
                                            Event 2: 08:30:00L

                                            DIVERT
                                            ANDERSEN AFB
                                            N13°34.57' E144°55.47
                                            """;
    }

}