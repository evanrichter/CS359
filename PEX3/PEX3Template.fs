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
    raise (Pex3Exception("Not yet implemented."))


//------------------------------------------------------------------------------
(*
makeDifference a1 a2
PURPOSE: returns a new expression for a1 - a2
PRECONDITIONS: a1 and a2 are valid expressions
POSTCONDITIONS: expression representing a1 - a2 or reduced form
                if either a2 is zero or both are numbers
EXAMPLE USES: makeDifference (Variable "x") (Number 5.0) returns Subtract(Variable "x", Number 5)
              makeDifference (Variable "x") (Number 0.0) returns Variable "x"
              makeDifference (Number 6.0) (Number 11.0) returns Number -5.0
*)
let makeDifference a1 a2 =
    raise (Pex3Exception("Not yet implemented."))


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
    raise (Pex3Exception("Not yet implemented."))



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
    raise (Pex3Exception("Not yet implemented."))




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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

//------------------------------------------------------------------------------
(*
makeExponential a1
PURPOSE: returns a new expression for the exponential of a1
PRECONDITIONS: a1 is a valid expression
POSTCONDITIONS: expression representing the exponential of a1 or reduced form if a1 is a number
EXAMPLE USES: makeExponential (Variable "x") returns Exponential(Variable "x")
              makeExponential (Number 1.0) returns Number(2.718281828) or something REALLY close to 2.718281828
*)
let makeExponential a1 =
    raise (Pex3Exception("Not yet implemented."))

//------------------------------------------------------------------------------
(*
replace var value expr
PURPOSE: replaces variable VAR with value VALUE in expression expr
PRECONDITIONS: VAR is the variable of type string, VALUE is numeric value of type int,
               expr is an expression
POSTCONDITIONS: returns the expr expression with VAR replaced by VALUE
EXAMPLE USE: replace "x" 4.0 (Add(Variable "x", (Multiply(Number 3.0, Variable "x"))))
                returns Add(Number 4.0, Multiply(Number 3.0, Number 4.0))
*)
let rec replace var value expr =
    raise (Pex3Exception("Not yet implemented."))


//-----------------------------------------------------------------------------
(*
derivative expr var
PURPOSE:  computes the symbolic derivative of some valid expression expr
PRECONDITIONS: expr is an expression
POSTCONDITIONS: returns expr differentiated with respect to var as an expression
EXAMPLE USE: derivative (Add(Variable "x", Number 5.0)) "x";; returns 1.0
*)
let rec derivative expr var =
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))


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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))


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
    raise (Pex3Exception("Not yet implemented."))


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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

//------------------------------------------------------------------------------
(*
toInfixString expr
PURPOSE:  returns the string representation of the given expression in INFIX notation
PRECONDITIONS: expr is an expression
POSTCONDITIONS: returns expr  as a fully-parenthesized string in INFIX notation
EXAMPLE USES: toInfixString (Power(Number 6.0, Exponential(Variable "x")))
              returns "(6^(exp(x)))"
*)
let rec toInfixString expr =
    raise (Pex3Exception("Not yet implemented."))


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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))



//------------------------------------------------------------------------------
(* evaluate expr
PURPOSE:  Evaluates those operations in expr that are composed of numbers
PRECONDITIONS: expr is an expression as defined as a differentiated union above
POSTCONDITIONS: returns expr with number-only operations evaluated
EXAMPLE USES: evaluate (Add( Multiply( Number 10.0, Number 3.0), Variable "x"))
              returns Add(Number 30.0, Variable "x")
*)
let rec evaluate expr =
    raise (Pex3Exception("Not yet implemented."))


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
    raise (Pex3Exception("Not yet implemented."))

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
    raise (Pex3Exception("Not yet implemented."))

[<EntryPoint>]
let main argv =
    0 // return an integer exit code


Add(Add(Multiply(Number 6.0,Power(Variable "x",Number 2.0)),Variable "x"),Number 3.0);;
