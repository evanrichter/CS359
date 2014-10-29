type expression =
  | Variable of String
  | Number of float
  | Add of expression * expression