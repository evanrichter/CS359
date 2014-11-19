parent(kim,evan).
parent(al,evan).

parent(bert,conner).
parent(kim,conner).
person(conner).
gender(conner,m).

spouse(kim,al).

person(kim).
person(al).
person(evan).

gender(evan,m).
gender(al,m).
gender(kim,f).


parent(june,al).
gender(june,f).
person(june).
spouse(june,john).
person(john).
gender(john,m).
parent(john,al).

parent(rita,kim).
gender(kim,f).
person(rita).
spouse(rita,ernie).
person(ernie).
gender(ernie,m).
parent(ernie,kim).

spouse(X,Y) :- spouse(Y,X).

mother(Mama, Child) :-
	parent(Mama, Child),
	gender(Mama, Child),
	person(Mama),
	person(Child).

father(P,C) :-
	parent(P,C),
	gender(P,C),
	person(P),
	person(C).

grandparent(G,C) :-
	parent(P,C),
	parent(G,P),
	person(G),
	person(C),
	person(P).

sibling(S,Me) :-
	parent(P,S),
	parent(P,Me),
	S \= Me,
	person(P),
	person(S),
	person(Me).

aunt(A,B) :-
	sibling(A,P),
	parent(P,B),
	gender(A,f),
	person(A),
	person(B),
	person(P).
