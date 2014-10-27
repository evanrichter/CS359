type proposition = 
  |True
  |False
  |Not of proposition
  |And of proposition * proposition
  | Or of proposition * proposition
  |Xor of proposition * proposition