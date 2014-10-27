let rec delDups li =
  match li with
  |[only] -> [only]
  |x :: (y :: tail) when x = y -> x :: tail
  |hd :: tail -> hd :: delDups (tail);;
