(*------------------------------------------------------------------------------
file:  pex3_solution.fsx
author: Maj Ross
based on code by: Dr. Hadfield
section: CS359
project: PEX3
purpose: To develop a symbolic differentiator

Some of these functions are filled in for you to help get you started.  --MPR *)


//-----------------------------------------------------------------------------------
// Definitions
// The code in this section will be provided to students
open System

//A differentiated union
type expression =
| Variable of String
| Number of float
| Add of expression * expression
| Subtract of expression * expression
| Multiply of expression * expression
| Divide of expression * expression
| Power of expression * expression
| Sine of expression
| Cosine of expression
| Tangent of expression
| Logarithm of expression    //NATURAL logarithm of expression
| Exponential of expression  //e to the expression

exception Pex3Exception of String


//------------------------------------------------------------------------------
(*
(makeSum a1 a2)
PURPOSE: returns a new expression for a1 + a2
PRECONDITIONS: a1 and a2 are valid expressions
POSTCONDITIONS: expression representing a1 + a2 or reduced form
                if either a1 or a2 is zero or both are numbers
EXAMPLE USES: (makeSum (Variable "x") (Number 5.0)) returns Add(Variable "x", Number 5.0)
              (makeSum (Variable "x") (Number 0.0)) returns Variable "x"
              (makeSum (Number 6.0) (Number 11.0)) returns Number 17.0
*)
let makeSum a1 a2 =
    match a1, a2 with
    |Number n1, Number n2 -> Number ( n1 + n2 )
    |s, Number n | Number n, s -> if n=0.0 then s
                                  else Add(s, Number n)
    |x,y -> Add(x,y)


//------------------------------------------------------------------------------
(*
makeDifference a1 a2
PURPOSE: returns a new expression for a1 - a2
PRECONDITIONS: a1 and a2 are valid expressions
POSTCONDITIONS: expression representing a1 - a2 or reduced form
                if either a2 is zero or both are numbers
EXAMPLE USES: makeDifference (Variable "x") (Number 5.0) returns Subtract(Variable "x", Number 5.0)
              makeDifference (Variable "x") (Number 0.0) returns Variable "x"
              makeDifference (Number 6.0) (Number 11.0) returns Number -5.0
*)
let makeDifference a1 a2 =
    match a1, a2 with
    |Number n1, Number n2 -> Number ( n1 - n2 )
    |s, Number n when n=0.0 -> s
    |x, y -> Subtract(x,y)


//------------------------------------------------------------------------------
(*
makeProduct a1 a2
PURPOSE: returns a new expression for a1 * a2
PRECONDITIONS: a1 and a2 are valid expressions
POSTCONDITIONS: expression representing a1 * a2 or reduced form in any of these cases:
                1) a1 or a2 are 1
                2) a1 or a2 are 0
                3) both a1 and a2 are numbers
EXAMPLE USES: (makeProduct (Variable "x") (Number 5.0)) returns Multiply(Variable "x", Number 5.0)
              (makeProduct (Variable "x") (Number 0.0)) returns Number 0.0
              (makeProduct (Variable "x") (Number 1.0)) returns Variable "x"
              (makeProduct (Number 6.0) (Number 11.0)) returns Number 66.0
*)
let makeProduct a1 a2 =
    match a1, a2 with
    |Number n1, Number n2 -> Number (n1 * n2 * 1.0)
    |x, Number n | Number n, x when n = 1.0 -> x
    |x, Number n | Number n, x when n = 0.0 -> Number 0.0
    |x,y -> Multiply(x, y)


//------------------------------------------------------------------------------
(*
makeQuotient a1 a2
PURPOSE: returns a new expression for a1 / a2
PRECONDITIONS: a1 and a2 are valid expressions
POSTCONDITIONS: expression representing a1 / a2 or reduced form in any of these cases:
                1) a2 is 1
                2) a1 is 0
                3) both a1 and a2 are numbers
EXAMPLE USES: (makeQuotient (Variable "x") (Number 5.0)) returns Divide(Variable "x", Number 5.0)
              (makeQuotient (Number 0.0) (Variable "x")) returns Number 0.0
              (makeQuotient (Variable "x") (Number 1.0)) returns Variable "x"
              (makeQuotient (Number 12.0) (Number 6.0)) returns Number 2.0
*)
let makeQuotient a1 a2 =
    match a1, a2 with
    |x, Number n when n=1.0 -> x
    |x, Number n when n=0.0 -> raise (Pex3Exception("Divide by zero!"))
    |Number n, x when n=0.0 -> Number 0.0
    |x, y when x=y -> Number 1.0
    |Number n1, Number n2 -> Number (n1 / n2 / 1.0)
    |x, Number n -> Divide(x, Number n)
    |x, y -> Divide(x,y)


//------------------------------------------------------------------------------
(*
makePower a1 a2
PURPOSE: returns a new expression for a1 raised to the a2 power
PRECONDITIONS: a1 and a2 are valid expressions
POSTCONDITIONS: expression representing a1 raised to the a2 or reduced form in any of these cases:
                1) a1 or a2 are 1
                2) a1 or a2 are 0
                3) both a1 and a2 are numbers
EXAMPLE USES: makePower (Variable "x") (Number 5.0) returns Power(Variable "x", Number 5.0)
              makePower (Variable "x") (Number 0.0) returns Number 1.0
              makePower (Variable "x") (Number 1.0) returns Variable "x"
              makePower (Number 2.0) (Number 5.0) returns Number 32.0
*)
let makePower a1 a2 =
    match a1, a2 with
    |Number n, x when n=1.0 or n=0.0 -> Number n
    |x, Number n when n=0.0 -> Number 1.0
    |x, Number n when n=1.0 -> x
    |Number n1, Number n2 -> Number (n1**n2 * 1.0)
    |x, y -> Power(x, y)

//------------------------------------------------------------------------------
(*
makeSine a1
PURPOSE: returns a new expression for the sine of a1
PRECONDITIONS: a1 is a valid expression
POSTCONDITIONS: expression representing the sine of a1 or reduced form if a1 is a number
EXAMPLE USES: makeSine (Variable "x")
              returns Sine(Variable "x")
              makeSine (Number 3.14159265359)
              returns Number(0.0) or something REALLY close to 0.0
*)
let makeSine a1 =
    match a1 with
    |Number n -> Number (1.0 * sin n)
    |x -> Sine(x)

//------------------------------------------------------------------------------
(*
makeCosine a1
PURPOSE: returns a new expression for the cosine of a1
PRECONDITIONS: a1 is a valid expression
POSTCONDITIONS: expression representing the cosine of a1 or reduced form if a1 is a number
EXAMPLE USES: makeCosine (Variable "x") returns Cosine(Variable "x")
              makeCosine (Number 1.5707963268) returns Number(0.0) or something REALLY close to 0.0
*)
let makeCosine a1 =
    match a1 with
    |Number n -> Number (1.0 * cos n)
    |x -> Cosine(x)

//------------------------------------------------------------------------------
(*
makeTangent a1
PURPOSE: returns a new expression for the tangent of a1
PRECONDITIONS: a1 is a valid expression
POSTCONDITIONS: expression representing the cosine of a1 or reduced form if a1 is a number
EXAMPLE USES: makeTangent (Variable "x") returns Tangent(Variable "x")
              makeTangent (Number 3.14159265359) returns Number(0.0) or something REALLY close to 0.0
*)
let makeTangent a1 =
    match a1 with
    |Number n -> Number (1.0 * tan n)
    |x -> Tangent(x)

//------------------------------------------------------------------------------
(*
makeLogarithm a1
PURPOSE: returns a new expression for the natural log of a1
PRECONDITIONS: a1 is a valid expression
POSTCONDITIONS: expression representing the natural log of a1 or reduced form if a1 is a number
EXAMPLE USES: makeLogarithm (Variable "x") returns Logarithm(Variable "x")
              makeLogarithm (Number 2.718281828) returns Number(1.0) or something REALLY close to 1.0
*)
let makeLogarithm a1 =
    match a1 with
    |Number n -> Number (1.0 * log n)
    |x -> Logarithm(x)

//------------------------------------------------------------------------------
(*
makeExponential a1
PURPOSE: returns a new expression for the exponential of a1
PRECONDITIONS: a1 is a valid expression
POSTCONDITIONS: expression representing the exponential of a1 or reduced form if a1 is a number
EXAMPLE USES: makeExponential (Variable "x") returns Exponential(Variable "x")
              makeExponential (Number 1.0) returns Number 2.718281828 or something REALLY close to 2.718281828
*)
let makeExponential a1 =
    match a1 with
    |Number n -> Number (1.0 * exp n)
    |x -> Exponential(x)

//------------------------------------------------------------------------------
(*
replace var value expr
PURPOSE: replaces variable VAR with value VALUE in expression expr
PRECONDITIONS: VAR is the variable of type string, VALUE is numeric value of type float,
               expr is an expression
POSTCONDITIONS: returns the expr expression with VAR replaced by VALUE
EXAMPLE USE: replace "x" 4.0 (Add(Variable "x", (Multiply(Number 3.0, Variable "x"))))
                returns Add(Number 4.0, Multiply(Number 3.0, Number 4.0))
*)
let rec replace var value expr =
    match expr with
    |Number n -> Number n
    |Variable s when s = var -> Number value
    |Add(e1, e2)      -> makeSum (replace var value e1) (replace var value e2)
    |Subtract(e1, e2) -> makeDifference (replace var value e1) (replace var value e2)
    |Multiply(e1, e2) -> makeProduct (replace var value e1) (replace var value e2)
    |Divide(e1, e2)   -> makeQuotient (replace var value e1) (replace var value e2)
    |Power(e1, e2)    -> makePower (replace var value e1) (replace var value e2)
    |Sine(e)          -> makeSine (replace var value e)
    |Cosine(e)        -> makeCosine (replace var value e)
    |Tangent(e)       -> makeTangent (replace var value e)
    |Logarithm(e)     -> makeLogarithm (replace var value e)
    |Exponential(e)   -> makeExponential (replace var value e)


//-----------------------------------------------------------------------------
(*
derivative expr var
PURPOSE:  computes the symbolic derivative of some valid expression expr
PRECONDITIONS: expr is an expression
POSTCONDITIONS: returns expr differentiated with respect to var as an expression
EXAMPLE USE: derivative (Add(Variable "x", Number 5.0)) "x";; returns Number 1.0
*)
let rec derivative expr var =
    match expr with
    |Number n       -> Number 0.0
    |Variable s     -> derivativeVariable expr var
    |Add(a,b)       -> derivativeSum expr var
    |Subtract(a,b)  -> derivativeDifference expr var
    |Multiply(a,b)  -> derivativeProduct expr var
    |Divide(a,b)    -> derivativeQuotient expr var
    |Power(a,b)     -> derivativePower expr var
    |Sine(a)        -> derivativeSine expr var
    |Cosine(a)      -> derivativeCosine expr var
    |Tangent(a)     -> derivativeTangent expr var
    |Logarithm(a)   -> derivativeLogarithm expr var
    |Exponential(a) -> derivativeExponential expr var

//-----------------------------------------------------------------------------
(*
derivativeVariable expr var
PURPOSE:  returns symbolic derivative of a variable
PRECONDITIONS: expr is a valid expression containing only a variable,
               var is the variable of differentiation of type string
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USE: derivativeVariable (Variable "a") "a"
             returns 1
*)
and derivativeVariable expr var =
    match expr with
    |Variable s -> if s = var then Number 1.0
                   else Number 0.0
    |_ -> raise (Pex3Exception("Not a Variable"))

//------------------------------------------------------------------------------
(*
derivativeSum expr var
PURPOSE:  returns the symbolic derivative of a sum with respect to var
PRECONDITIONS: expr is an expression containing a sum as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USE: derivativeSum (Add(Variable "a", Variable "b")) "a" returns Number 1.0
*)
and derivativeSum expr var =
    match expr with
    |Add(e1, e2) -> makeSum (derivative e1 var) (derivative e2 var)
    |_ -> raise (Pex3Exception("Not a Sum"))


//------------------------------------------------------------------------------
(*
derivativeDifference expr var
PURPOSE:  returns the symbolic derivative of a difference with respect to var
PRECONDITIONS: expr is an expression containing a difference as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USE: derivativeDifference (Subtract(Variable "a", Variable "b")) "a" returns Number 1.0
*)
and derivativeDifference expr var =
    match expr with
    |Subtract(e1,e2) -> makeDifference (derivative e1 var) (derivative e2 var)
    |_ -> raise (Pex3Exception("Not a Difference"))

//------------------------------------------------------------------------------
(*
derivativeProduct expr var
PURPOSE:  returns the symbolic derivative of a product with respect to var
PRECONDITIONS: expr is an expression containing a product as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr product with respect to var
EXAMPLE USE: derivativeProduct (Multiply(Variable "a", Variable "b")) "a" returns Variable "b"
*)
and derivativeProduct expr var =
    match expr with
    |Multiply(e1, e2) -> makeSum (makeProduct (derivative e1 var) e2) (makeProduct e1 (derivative e2 var))
    |_ -> raise (Pex3Exception("Not a Product"))

//------------------------------------------------------------------------------
(*
derivativeQuotient expr var
PURPOSE:  returns the symbolic derivative of a quotient with respect to var
PRECONDITIONS: expr is an expression containing a quotient as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USES: derivativeQuotient (Divide(Variable "a", Variable "b")) "a"
              returns Divide (Variable "b",Power (Variable "b",Number 2.0))
*)

and derivativeQuotient expr var =
    match expr with
    //quotient rule
    |Divide(e1,e2) -> makeQuotient (makeDifference (makeProduct e2 (derivative e1 var)) (makeProduct (e1) (derivative e2 var)) )
                                   (makePower e2 (Number 2.0))
    |_ -> raise (Pex3Exception("Not a Quotient"))

//------------------------------------------------------------------------------
(*
derivativePower expr var
PURPOSE:  returns the symbolic derivative of a power with respect to var
PRECONDITIONS: expr is an expression containing a power as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USES: derivativePower (Power(Variable "a", Number 4.0)) "a"
              returns Multiply (Number 4.0, Power(Variable "a", Number 3.0))
*)
and derivativePower expr var =
    match expr with
    //Elementary Power Rule
    |Power(e,Number n) -> makeProduct (makeProduct (Number n) (makePower e (makeDifference (Number n) (Number 1.0)))) (derivative e var)
    //Generalized Power Rule, from Wikipedia "Differentiation Rules"
    |Power(f,g) -> makeProduct expr (makeSum (makeProduct (derivative f var) (makeQuotient g f)) (makeProduct (derivative g var) (makeLogarithm f)))
    |_ -> raise (Pex3Exception("Not a Power"))

//------------------------------------------------------------------------------
(*
derivativeSine expr var
PURPOSE:  returns the symbolic derivative of a sine with respect to var
PRECONDITIONS: expr is an expression containing a sine as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USES: derivativeSine (Sine(Multiply(Variable "a", Number 2.0))) "a"
              returns Multiply (Cosine (Multiply (Variable "a",Number 2.0)),Number 2.0)
*)
and derivativeSine expr var =
    match expr with
    |Sine(e) -> makeProduct (makeCosine e) (derivative e var)
    |_ -> raise (Pex3Exception("Not a Sine"))

//------------------------------------------------------------------------------
(*
derivativeCosine expr var
PURPOSE:  returns the symbolic derivative of a cosine with respect to var
PRECONDITIONS: expr is an expression containing a cosine as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USES: derivativeCosine (Cosine(Multiply(Variable "a", Number 2.0))) "a"
              returns Subtract( Number 0.0, Multiply (Sine (Multiply (Variable "a",Number 2.0)),Number 2.0))
*)
and derivativeCosine expr var =
    match expr with
    |Cosine(e) -> makeProduct (makeDifference (Number 0.0) (makeSine e)) (derivative e var)
    |_ -> raise (Pex3Exception("Not a Cosine"))


//------------------------------------------------------------------------------
(*
derivativeTangent expr var
PURPOSE:  returns the symbolic derivative of a tangent with respect to var
PRECONDITIONS: expr is an expression containing a tangent as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USES: derivativeTangent (Tangent(Variable "a")) "a"
              returns Divide(Number 1.0, Power(Cosine(Variable "a")), Number 2.0)
*)
and derivativeTangent expr var =
    match expr with
    |Tangent(e) -> makeProduct (makeQuotient (Number 1.0) (makePower (makeCosine e) (Number 2.0))) (derivative e var)
    |_ -> raise (Pex3Exception("Not a Tangent"))


//------------------------------------------------------------------------------
(*
derivativeLogarithm expr var
PURPOSE:  returns the symbolic derivative of a logarithm with respect to var
PRECONDITIONS: expr is an expression containing a logarithm as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USES: derivativeLogarithm (Logarithm(Variable "a")) "a"
              returns Divide(Number 1.0, Variable "a")
*)
and derivativeLogarithm expr var =
    match expr with
    |Logarithm(e) -> makeProduct (makeQuotient (Number 1.0) e) (derivative e var)
    |_ -> raise (Pex3Exception("Not a Logarithm"))

//------------------------------------------------------------------------------
(*
derivativeExponential expr var
PURPOSE:  returns the symbolic derivative of an exponenetial with respect to var
PRECONDITIONS: expr is an expression containing an exponential as its outer calculation,
               var is the variable of differentiation
POSTCONDITIONS: returns expr differentiated with respect to var
EXAMPLE USES: derivativeExp (Exponential(Variable "a")) "a"
              returns Exponential(Variable "a")
*)
and derivativeExponential expr var =
    match expr with
    |Exponential(e) -> makeProduct (expr) (derivative e var)
    |_ -> raise (Pex3Exception("Not an Exponential"))

//------------------------------------------------------------------------------
(*
toInfixString expr
PURPOSE:  returns the string representation of the given expression in INFIX notation
PRECONDITIONS: expr is an expression
POSTCONDITIONS: returns expr  as a fully-parenthesized string in INFIX notation
EXAMPLE USES: toInfixString (Power(Number 6.0, Exponential(Variable "x")))
              returns "(6^(exp x))"
*)
let rec toInfixString expr =
    match expr with
    |Number n         -> if (n % 1.0) > 0.0 then sprintf "%.15f" n
                         else sprintf "%.0f" n
    |Variable s       -> s
    |Add(e1, e2)      -> "(" + (toInfixString e1) + "+" + (toInfixString e2) + ")"
    |Subtract(e1, e2) -> "(" + (toInfixString e1) + "-" + (toInfixString e2) + ")"
    |Multiply(e1, e2) -> "(" + (toInfixString e1) + "*" + (toInfixString e2) + ")"
    |Divide(e1, e2)   -> "(" + (toInfixString e1) + "/" + (toInfixString e2) + ")"
    |Power(e1, e2)    -> "(" + (toInfixString e1) + "^" + (toInfixString e2) + ")"
    |Sine(e)          -> "(sin " + (toInfixString e) + ")"
    |Cosine(e)        -> "(cos " + (toInfixString e) + ")"
    |Tangent(e)       -> "(tan " + (toInfixString e) + ")"
    |Logarithm(e)     -> "(log " + (toInfixString e) + ")"
    |Exponential(e)   -> "(exp " + (toInfixString e) + ")"


//------------------------------------------------------------------------------
(*
derivativeInfix expr var
PURPOSE:  Computes the derivative of the expression expr with respect to variable VAR.
          Returns a string representing the derivative in infix notation.
PRECONDITIONS: expr is an expression as defined as a differentiated union above
POSTCONDITIONS: returns expr differeniated with respect to var as a fully-parenthesized
                string in INFIX notation
EXAMPLE USES: derivativeInfix (Power(Exponential(Variable "x"),  Number 6.0)) "x"
              returns "(6*(((exp(x))^5)*(exp(x))))"
*)
let derivativeInfix expr var =
    toInfixString (derivative expr var)

//------------------------------------------------------------------------------
(*
nthDerivativeInfix expr var N
PURPOSE:  Computes the Nth derivative of the expression expr with respect to variable var.
          Returns a string representing the derivative in infix notation.
PRECONDITIONS: expr is an expression as defined as a differentiated union above
               var is a string representing variable of differentiation
               N is an integer representing number of times to differentiate
POSTCONDITIONS: returns expr differeniated with respect to var as a fully-parenthesized
                string in INFIX notation
EXAMPLE USES: nthDerivativeInfix (Add( Multiply( Number 5.0, Power(Variable "x" , Number 2.0)) ,
                                      Add( Multiply(Number 3.0, Variable "x") , Number 7.0)
                                    )
                                 ) "x" 2;;
              returns "10"
*)
let rec nthDerivativeInfix expr var N =
    match N with
    |0 -> toInfixString expr
    |n -> nthDerivativeInfix (derivative expr var) var (n-1)
    |_ -> raise(Pex3Exception("Can't take a negative Nth derivative"))



//------------------------------------------------------------------------------
(* evaluate expr
PURPOSE:  Evaluates those operations in expr that are composed of numbers
PRECONDITIONS: expr is an expression as defined as a differentiated union above
POSTCONDITIONS: returns expr with number-only operations evaluated
EXAMPLE USES: evaluate (Add( Multiply( Number 10.0, Number 3.0), Variable "x"))
              returns Add(Number 30.0, Variable "x")
*)
let rec evaluate expr =
    match expr with
    |Number n         -> Number n
    |Variable s       -> Variable s
    |Add(e1, e2)      -> makeSum (evaluate e1) (evaluate e2)
    |Subtract(e1, e2) -> makeDifference (evaluate e1) (evaluate e2)
    |Multiply(e1, e2) -> makeProduct (evaluate e1) (evaluate e2)
    |Divide(e1, e2)   -> makeQuotient (evaluate e1) (evaluate e2)
    |Power(e1, e2)    -> makePower (evaluate e1) (evaluate e2)
    |Sine(e)          -> makeSine (evaluate e)
    |Cosine(e)        -> makeCosine (evaluate e)
    |Tangent(e)       -> makeTangent (evaluate e)
    |Logarithm(e)     -> makeLogarithm (evaluate e)
    |Exponential(e)   -> makeExponential (evaluate e)


//------------------------------------------------------------------------------
(*
evaluateDerivativeInfix expr var value
PURPOSE:  Computes the derivative of the expression expr with respect to variable var.
          Replaces var with value.  Returns a string representing the result in infix notation.
PRECONDITIONS: expr is an expression as defined as a differentiated union above
               var is a string representing variable of differentiation
               value is an float (NOT a Number type)
POSTCONDITIONS: returns expr differeniated with respect to var as a fully-parenthesized
                string in INFIX notation with var replaced by value
EXAMPLE USES: evaluateDerivativeInfix (Add( Multiply( Number 10.0, Power (Variable "x", Number 2.0)), Number 3.0)) "x" 1.0
              returns "20"
*)
let evaluateDerivativeInfix expr var value =
    toInfixString (replace var value (derivative expr var))

//--------------------------------------------------------------------------------
(*
evaluateNthDerivativeInfix expr var value N
PURPOSE:  Computes the Nth derivative of the expression expr with respect to variable var and then evaluated at a value of value
          for the variable var.  Returns a string representing the result in infix notation.
PRECONDITIONS: expr is an expression as defined as a differentiated union above
               var is a string representing variable of differentiation
               value is an float (NOT a Number type)
               N is an integer
POSTCONDITIONS: returns expr differeniated N times with respect to var as a fully-parenthesized
                string in INFIX notation with var replaced by value
EXAMPLE USES: evaluateNthDerivativeInfix (Add( Multiply( Number 10.0, Power (Variable "x", Number 3.0)), Number 3.0)) "x" 2.0 2
              returns "120"
*)
let rec evaluateNthDerivativeInfix expr var value N =
    match N with
    |1 -> evaluateDerivativeInfix expr var value
    |n -> evaluateNthDerivativeInfix (derivative expr var) var value (n-1)
    |_ -> raise(Pex3Exception("Can't take a negative Nth derivative"))

































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
            "derivative (Divide(Variable \"x\", Number 2.0)) \"x\" failed to return Number 0.5";
        derivative,
            (Divide(Variable "a", Variable "x"), "x"),
            Divide(Subtract(Number 0.0, Variable "a"), Power(Variable "x", Number 2.0)),
            "derivative (Divide(Variable \"a\", Variable \"x\")) \"x\"" +
            " failed to return Divide(Subtract(Number 0.0, Variable \"a\"), Power(Variable \"x\", Number 2.0))";
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


[<EntryPoint>]
let main argv =
    0 // return an integer exit code
