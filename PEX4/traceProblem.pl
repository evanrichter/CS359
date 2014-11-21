parent(tim, matt).
parent(shirley, matt).
parent(anne, tim).
parent(paul, tim).
parent(robert, shirley).
parent(rita, shirley).
parent(robert, bob).
parent(rita, bob).

sibling(S1, S2) :-
	parent(P, S1),
	parent(P, S2),
	S1 \= S2.

uncleOrAunt(UA, N) :-
	parent(P, N),
	sibling(P, UA).
