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
        }
    
}