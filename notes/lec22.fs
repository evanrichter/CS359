let gradePicker score = 
	match score with
		| 100 -> "A+"
		| score when score < 80 -> "C"
		| score when score < 90 -> "
		| _ -> "A"

