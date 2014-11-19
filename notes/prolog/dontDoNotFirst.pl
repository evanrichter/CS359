% This file shows why it is bad practice to
% perform any not predicates on unbound variables
% Consider code below

parent(tim, amy).
parent(tim, allison).

sibling(S1, S2) :-
	S1 \= S2,
	parent(P, S1),
	parent(P, S2).













% It is obvious that amy and allison are siblings.
% Prolog is able to confirm that for us...
% sibling(amy, allison).
% > true
%
% However, consider query to find all siblings of amy
% sibling(amy, Result).
% false
%
% The problem is that amy \= _G106 (unbound) evaluates
% to false
% In English, "Hey Prolog, can you prove that amy
% unifies with NOTHING else in the database?"
% Prolog's reply: "Nope.  It's possible that amy unifies
% with something.  Thus, I'll return false."








