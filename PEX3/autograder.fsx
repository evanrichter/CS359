//Autograder
//Place the contents of this file into your PEX3 template
//It must go AFTER your last function and BEFORE the part that says [<EntryPoint>]
//To use enter
//autograde 0;;
//at the F# interactive window command prompt

let binaryMakeFunctionTestCases =
    [
        makeSum, (Variable "x",Number 0.0), Variable "x", "makeSum (Variable \"x\") (Number 0.0) failed to return Variable \"x\"";
        makeSum, (Number 6.0, Number 8.0), Number 14.0, "makeSum (Number 6.0) (Number 8.0) failed to return (Number 14.0)";
        makeDifference, (Number 3.0, Number 4.0), Number -1.0, "makeDifference (Number 3.0) (Number 4.0) failed to return (Number -1.0)"
        makeDifference, (Number 0.0, Variable "x"), Subtract(Number 0.0, Variable "x"), "makeDifference (Number 0.0) (Variable \"x\") failed to return Subtract(Number 0.0, Variable \"x\")";
        makeDifference, (Variable "x", Number 0.0), Variable "x", "makeDifference (Variable \"x\") (Number 0.0)  failed to return Variable \"x\")";
        makeDifference, (Variable "x", Number 5.0), Subtract(Variable "x", Number 5.0), "makeDifference (Variable \"x\") (Number 5.0)  failed to return Subtract(Variable \"x\", Number 5.0)";
        makeQuotient, (Number 3.0, Number 3.0), Number 1.0, "makeQuotient (Number 3.0) (Number 3.0) failed to return (Number 1.0)";
        makeQuotient, (Variable "x", Variable "x"), Number 1.0, "makeQuotient (Variable \"x\") (Variable \"x\") failed to return (Number 1.0)";
        makeQuotient, (Number 0.0, Variable "x"), Number 0.0, "makeQuotient (Number 0.0) (Variable \"x\") failed to return (Number 0.0)";
        makeQuotient, (Variable "x", Number 5.0), Divide(Variable "x", Number 5.0), "makeQuotient (Variable \"x\") (Number 5.0) failed to return Divide(Variable \"x\", Number 5.0)";
    ]

let unaryMakeFunctionTestCases =
    [
        makeSine, Add(Variable "x", Number 5.0), Sine(Add(Variable "x", Number 5.0)), "makeSine (Add(Variable \"x\", Number 5.0)) failed to return Sine(Add(Variable \"x\", Number 5.0))";
        makeCosine, Add(Variable "x", Number 5.0), Cosine(Add(Variable "x", Number 5.0)), "makeCosine (Add(Variable \"x\", Number 5.0)) failed to return Cosine(Add(Variable \"x\", Number 5.0))";
        makeExponential, Add(Variable "x", Number 5.0), Exponential(Add(Variable "x", Number 5.0)), "makeExponential (Add(Variable \"x\", Number 5.0)) failed to return Exponential(Add(Variable \"x\", Number 5.0))";
    ]

let toInfixStringTestCases =
    [
        toInfixString, Variable "z", "z", "toInfixString (Variable \"z\") failed to return \"z\"";
        toInfixString, Number 3.0, "3", "toInfixString (Variable \"z\") failed to return \"3\"";
        toInfixString, Add(Variable "x", Variable "y"), "(x+y)", "toInfixString (Add(Variable \"x\", Variable \"y\")) failed to return \"(x+y)\"";
        toInfixString, Subtract(Variable "x", Variable "y"), "(x-y)", "toInfixString (Subtract(Variable \"x\", Variable \"y\")) failed to return \"(x-y)\"";
        toInfixString, Multiply(Variable "x", Variable "y"), "(x*y)", "toInfixString (Multiply(Variable \"x\", Variable \"y\")) failed to return \"(x*y)\"";
        toInfixString, Power(Variable "x", Number 3.0), "(x^3)", "toInfixString (Power(Variable \"x\", Number 3.0) failed to return \"(x^3)\"";
        toInfixString, Divide(Variable "x", Variable "y"), "(x/y)", "toInfixString (Divide(Variable \"x\", Variable \"y\")) failed to return \"(x/y)\"";
        toInfixString, Sine(Add(Variable "x", Number 3.0)), "(sin (x+3))", "toInfixString (Sine(Add(Variable \"x\", Number 3.0))) failed to return \"(sin (x+3))\"";
        toInfixString, Cosine(Multiply(Variable "x", Number 3.0)), "(cos (x*3))", "toInfixString (Cosine(Multiply(Variable \"x\", Number 3.0))) failed to return \"(cos (x*3))\"";
        toInfixString, Logarithm(Divide(Variable "x", Number 3.0)), "(log (x/3))", "toInfixString (Logarithm(Divide(Variable \"x\", Number 3.0))) failed to return \"(log (x/3))\"";
        toInfixString, Exponential(Power(Variable "x", Number 3.0)), "(exp (x^3))", "toInfixString (Exponential(Power(Variable \"x\", Number 3.0))) failed to return \"(exp (x^3))\"";
        toInfixString, 
            Multiply(Add(Variable "x", Number 3.0), Cosine(Logarithm(Power(Variable "x", Variable "y" )))), 
            "((x+3)*(cos (log (x^y))))", 
            "toInfixString (Multiply(Add(Variable \"x\", Number 3.0), Cosine(Logarithm(Power(Variable \"x\", Variable \"y\" ))))) failed to return \"((x+3)*(cos (log (x^y))))\""

    ]

let derivativeTestCases =
    [
        derivative, 
            (Subtract(Number 3.0, Variable "x"), "x"), 
            Number -1.0, 
            "derivative (Subtract(Number 3.0, Variable \"x\")) \"x\" failed to return Number -1.0";
        derivative, 
            (Subtract(Number 3.0, Variable "y"), "x"), 
            Number 0.0, 
            "derivative (Subtract(Number 3.0, Variable \"y\")) \"x\" failed to return Number 0.0";
        derivative, 
            (Divide(Variable "x", Number 2.0), "x"), 
            Number 0.5, 
            "derivative (Subtract(Variable \"x\", Number 2.0)) \"x\" failed to return Number 0.5";
        derivative, 
            (Divide(Variable "a", Variable "x"), "x"), 
            Divide(Subtract(Number 0.0, Variable "a"), Power(Variable "x", Number 2.0)),
            "derivative (Divide(Variable \"a\", Variable \"x\")) \"x\"" +
            " failed to return Divide(Subtract(Number 0.0, Variable \"a\"), Power(Variable \"a\", Number 2.0))";
        derivative,
            (Divide(Multiply(Number 3.0, Variable "x"), Multiply (Variable "a", Variable "x") ),"x"),
            (Divide(Subtract(Multiply(Multiply(Variable "a", Variable "x"), Number 3.0), 
                             Multiply(Multiply(Number 3.0,Variable "x"),Variable "a")
                            ),
                    Power(Multiply(Variable "a",Variable "x"),Number 2.0)
                    )
            ),
            "derivative (Divide(Multiply(Number 3.0, Variable \"x\"), Multiply (Variable \"a\", Variable \"x\") ) \"x\""+
            " failed to return\n"+
            "(Divide(Subtract(Multiply(Number 3.0,Multiply(Variable \"a\", Variable \"x\")),\n"+ 
            "                 Multiply(Multiply(Number 3.0,Variable \"x\"),Variable \"a\")\n"+
            "                ),\n"+
            "        Power(Multiply(Variable \"a\",Variable \"x\"),Number 2.0)\n"+
            "       )\n"+
            ")";
        derivative, 
            ((Sine(Variable "x")), "x"), 
            Cosine(Variable "x"), 
            "derivative (Sine(Variable \"x\")) \"x\" failed to return Cosine(Variable \"x\")";
        derivative,
            ((Sine(Divide(Variable "x", Variable "y"))), "x"),
            Multiply(Cosine(Divide(Variable "x", Variable "y")),Divide(Variable "y", Power(Variable "y",Number 2.0))),
            "derivative (Sine(Divide(Variable \"x\", Variable \"y\"))) \"x\" failed to return\n"+
            "Multiply(Cosine(Divide(Variable \"x\", Variable \"y\")),Divide(Variable \"y\", Power(Variable \"y\",Number 2.0)))";
        derivative, 
            ((Cosine(Variable "x")), "x"), 
            Subtract(Number 0.0, Sine(Variable "x")), 
            "derivative (Cosine(Variable \"x\")) \"x\" failed to return Subtract(Number 0.0, Sine(Variable \"x\"))";
        derivative,
            ((Cosine(Divide(Variable "x", Variable "y"))), "x"),
            Multiply(Subtract(Number 0.0, Sine(Divide(Variable "x", Variable "y"))),Divide(Variable "y", Power(Variable "y",Number 2.0))),
            "derivative (Cosine(Divide(Variable \"x\", Variable \"y\"))) \"x\" failed to return\n"+
            "  Multiply\n"+
            "    (Subtract (Number 0.0,Sine (Divide (Variable \"x\",Variable \"y\"))),\n"+
            "     Divide (Variable \"y\",Power (Variable \"y\",Number 2.0)))";
        derivative,
            ((Tangent(Variable "x")), "x"), 
            Divide(Number 1.0, Power(Cosine(Variable "x"),Number 2.0)),
            "derivative (Tangent(Variable \"x\")) \"x\" failed to return Divide(Number 1.0, Power(Cosine(Variable \"x\"),Number 2.0))";
        derivative,
            ( Tangent(Cosine(Multiply(Number 3.0, Power(Variable "x", Number 4.0)))) , "x"),
            Multiply
                (Divide
                   (Number 1.0,
                    Power
                      (Cosine
                         (Cosine (Multiply (Number 3.0,Power (Variable "x",Number 4.0)))),
                       Number 2.0)),
                 Multiply
                   (Subtract
                      (Number 0.0,
                       Sine (Multiply (Number 3.0,Power (Variable "x",Number 4.0)))),
                    Multiply
                      (Number 3.0,Multiply (Number 4.0,Power (Variable "x",Number 3.0))))),
            "derivative (Tangent(Cosine(Multiply(Number 3.0, Power(Variable \"x\", Number 4.0))))) \"x\"\n"+
            "failed to return\n"+
            "  Multiply\n"+
            "   (Divide\n"+
            "      (Number 1.0,\n"+
            "       Power\n"+
            "         (Cosine\n"+
            "            (Cosine (Multiply (Number 3.0,Power (Variable \"x\",Number 4.0)))),\n"+
            "          Number 2.0)),\n"+
            "    Multiply\n"+
            "       (Subtract\n"+
            "          (Number 0.0,\n"+
            "           Sine (Multiply (Number 3.0,Power (Variable \"x\",Number 4.0)))),\n"+
            "        Multiply\n"+
            "          (Number 3.0,Multiply (Number 4.0,Power (Variable \"x\",Number 3.0)))))";
        derivative, ((Logarithm(Variable "x")), "x"), Divide(Number 1.0, Variable "x"),
            "derivative (Logarithm(Variable \"x\")) \"x\" failed to return Divide(Number 1.0, Variable \"x\")";
        derivative, 
            ( Logarithm(Cosine(Subtract(Variable "x",Number 3.0))), "x"),
            Multiply
                (Divide (Number 1.0,Cosine (Subtract (Variable "x",Number 3.0))),
                    Subtract (Number 0.0,Sine (Subtract (Variable "x",Number 3.0)))),
            "derivative ( Logarithm(Cosine(Subtract(Variable \"x\",Number 3.0)))) \"x\" failed to return\n"+
            "  Multiply\n"+
            "    (Divide (Number 1.0,Cosine (Subtract (Variable \"x\",Number 3.0))),\n"+
            "     Subtract (Number 0.0,Sine (Subtract (Variable \"x\",Number 3.0))))";
        derivative, ((Exponential(Variable "x")), "x"), Exponential(Variable "x"), 
            "derivative (Exponential(Variable \"x\")) \"x\" failed to return Exponential(Variable \"x\")";
        derivative,
            ((Exponential(Logarithm(Cosine(Multiply(Number 3.0, Variable "x"))))),"x"),
            Multiply
              (Exponential (Logarithm (Cosine (Multiply (Number 3.0,Variable "x")))),
               Multiply
                 (Divide (Number 1.0,Cosine (Multiply (Number 3.0,Variable "x"))),
                  Multiply
                    (Subtract (Number 0.0,Sine (Multiply (Number 3.0,Variable "x"))),
                     Number 3.0))),
            "derivative ((Exponential(Logarithm(Cosine(Multiply(Number 3.0, Variable \"x\")))))) \"x\"\n"+
            "failed to return\n"+
            "Multiply\n"+
            "  (Exponential (Logarithm (Cosine (Multiply (Number 3.0,Variable \"x\")))),\n"+
            "   Multiply\n"+
            "     (Divide (Number 1.0,Cosine (Multiply (Number 3.0,Variable \"x\"))),\n"+
            "      Multiply\n"+
            "        (Subtract (Number 0.0,Sine (Multiply (Number 3.0,Variable \"x\"))),\n"+
            "         Number 3.0)))";
    ]

let deivativeInfixTestCases =
    [ 
        derivativeInfix, 
            (Multiply(Logarithm(Power(Variable "x", Number 3.0)),Cosine(Divide(Variable "y",Variable "x"))), "x"), 
            "(((log (x^3))*((0-(sin (y/x)))*((0-y)/(x^2))))+((cos (y/x))*((1/(x^3))*(3*(x^2)))))", 
            "derivativeInfix\n"+
            " (Multiply(Logarithm(Power(Variable \"x\", Number 3.0)),Cosine(Divide(Variable \"y\",Variable \"x\")))) \"x\"\n"+
            "failed to return\n"+
            "(((log (x^3))*((0-(sin (y/x)))*((0-y)/(x^2))))+((cos (y/x))*((1/(x^3))*(3*(x^2)))))"
    ]

let nthDerivativeInfixTestCases =
    [
        nthDerivativeInfix, 
            (Power(Variable "x", Number 5.0), "x", 2), 
            "(5*(4*(x^3)))",
            "nthDerivativeInfix (Power(Variable \"x\", Number 5.0)) \"x\" 2 failed to return (5*(4*(x^3)))"
    ]

let evalDerivativeInfixTestCases =
    [
        evaluateDerivativeInfix,
            (Power(Variable "x", Number 5.0), "x", 4.0),
            "1280",
            "WRONG!"
    ]

let evalNthDerivativeInfixTestCases =
    [
        evaluateNthDerivativeInfix,
            (Power(Variable "x", Number 5.0), "x", 4.0, 3),
            "960",
            "evaluateNthDerivativeInfix (Power(Variable \"x\", Number 5.0)) \"x\" 4.0 3 failed to return \"960\"";
        evaluateNthDerivativeInfix,
            (Divide((Cosine(Logarithm(Power(Variable "x", Number 5.0))), Variable "x")), "x", 4.0, 3),
            "0.613487206162668",
            "evaluateNthDerivativeInfix (Divide((Cosine(Logarithm(Power(Variable \"x\", Number 5.0))), Variable \"x\"))) \"x\" 4.0 3\n"+
            "failed to return \"0.613487206162668\""

    ]

let gradeUnaryTest f test desiredResult=
    match test with
        arg -> (f arg ) = desiredResult

let gradeBinaryTest f test desiredResult=
    match test with
    arg1, arg2 -> (f arg1 arg2) = desiredResult


let gradeTernaryTest f test desiredResult=
    match test with
    arg1, arg2, arg3 -> (f arg1 arg2 arg3) = desiredResult

let gradeFournaryTest f test desiredResult=
    match test with
    arg1, arg2, arg3, arg4 -> (f arg1 arg2 arg3 arg4) = desiredResult
    
let autograde dummyVar =
    printfn "Checking for proper implementation of binary make functions..."
    for (f, test, desiredResult, failureMsg) in binaryMakeFunctionTestCases do
        try
            if (not (gradeBinaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
    printfn "Checking for proper implementation of unary make functions..."
    for (f, test, desiredResult, failureMsg) in unaryMakeFunctionTestCases do
        try
            if (not (gradeUnaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
    printfn "Checking for proper implementation of toInfixString..."
    for (f, test, desiredResult, failureMsg) in toInfixStringTestCases do
        try
            if (not (gradeUnaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
    printfn "Checking for proper implementation of derivative..."
    for (f, test, desiredResult, failureMsg) in derivativeTestCases do
        try
            if (not (gradeBinaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
    printfn "Checking for proper implementation of derivativeInfix..."
    for (f, test, desiredResult, failureMsg) in deivativeInfixTestCases do
        try
            if (not (gradeBinaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
    printfn "Checking for proper implementation of nthDerivativeInfix..."
    for (f, test, desiredResult, failureMsg) in nthDerivativeInfixTestCases do
        try
            if (not (gradeTernaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
    printfn "Checking for proper implementation of evalDerivativeInfix..."
    for (f, test, desiredResult, failureMsg) in evalDerivativeInfixTestCases do
        try
            if (not (gradeTernaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
    printfn "Checking for proper implementation of evalNthDerivativeInfixTestCases..."
    for (f, test, desiredResult, failureMsg) in evalNthDerivativeInfixTestCases do
        try
            if (not (gradeFournaryTest f test desiredResult)) then
                printfn "ERROR: %s" failureMsg
        with
            | Pex3Exception(exptMsg) -> printfn "EXCEPTION THROWN: %s\n%s" exptMsg failureMsg
