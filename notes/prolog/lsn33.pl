% Trace diagram practice using family
% This is DIFFERENT from the example given in lesson 30
% Let's say that allison is only my half sister
% We share the same father but not the same mother

parent(shirley, matt).
parent(tim, matt).
parent(tim, allison).

sibling(S1, S2) :-
	parent(P, S1),
	parent(P, S2),
	S1 \= S2.

% Trace diagram practice
a(a1,1).
a(_,2).
a(a3,_).

b(1,b1).
b(2,_).
b(_,b3).

c(X,Y) :- a(X,N), b(N,Y).

d(X,Y) :- a(X,N), b(Y,N).
d(X,Y) :- a(N,X), b(N,Y).


%number of occurrences of a particular item in a list
numOccurrences([],_,0).
numOccurrences([Head|Tail],Head,Result):-
	numOccurrences(Tail,Head,RemainingOccurrences),
	Result is 1 + RemainingOccurrences.
numOccurrences([_|Tail],X,Result):-
	numOccurrences(Tail,X,Result).


%append two lists together
myappend(Left,[],Left).
myappend(Left,[Head|Tail],Result):-
	myappend([Left|[Head]],Tail,Result).
