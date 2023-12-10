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
    
            public const  String problematic1 = """
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
        }
    
}