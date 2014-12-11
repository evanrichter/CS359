contains([Only],Only).
contains([Head|_],Head).
contains([_|Tail],Thing) :-
	contains(Tail,Thing).


delAll(_, [], []).
delAll(Element, [Element|Tail], NewTail) :-
	delAll(Element, Tail, NewTail).
delAll(Element, [NotElement|Tail], [NotElement|NewTail]) :-
	Element \= NotElement,
	delAll(Element, Tail, NewTail).



commanderOf(genJohnson, usafa).
commanderOf(genArmacost, df).
commanderOf(drCarlisle, dfcs).

unitOf(dfcs, df).
unitOf(df, usafa).
unitOf(U1, U2) :-
	U1 \= usafa,
	unitOf(U1, U3),
	unitOf(U3, U2).

memberOf(majRoss, dfcs).

commands(Leader, Subordinate) :-
	commanderOf(Leader, U),
	memberOf(Subordinate, Unit),
	unitOf(Unit, U),
	Leader \= Subordinate.
commands(Leader, Subordinate) :-
	commanderOf(Leader, U),
	commanderOf(Subordinate, Unit),
	unitOf(Unit, U),
	Leader \= Subordinate.
