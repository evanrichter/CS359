/*
*	Name:			Evan Richter
*	Class:		Comp Sci 359
*	Assignment:	Pex1
*	Date:			18 Sept 2014
*
*	Documentation:
*			No cadet help.
*			used the site below to help my switch-case with a character
*			<http://www.java2s.com/Code/C/Language-Basics/Howtouseswitchchar.htm>
*/

#include <stdio.h>
#include <stdlib.h>

typedef struct Sprig_struct {
   struct Leaf_struct* firstLeaf;
   struct Sprig_struct* leftSprig;
   struct Sprig_struct* parentSprig;
} Sprig;

typedef struct Leaf_struct {
   int key;
   struct Leaf_struct* nextLeaf;
   struct Leaf_struct* prevLeaf;
   struct Sprig_struct* currSprig;
   struct Sprig_struct* childSprig;
} Leaf;

void createSprig(Sprig* thisSprig, Sprig* parentSprig) {
	thisSprig->parentSprig = parentSprig;
}

void createLeaf(Leaf* thisLeaf, int key, Leaf* prevLeaf, Leaf* nextLeaf, Sprig* currSprig){
	thisLeaf->key = key;
	thisLeaf->prevLeaf = prevLeaf;
	thisLeaf->nextLeaf = nextLeaf;
	thisLeaf->currSprig = currSprig;
}

void addLeaf(Sprig* thisSprig, int key, int caliper){
	Leaf* thisLeaf = thisSprig->firstLeaf;
	
	if (thisLeaf == NULL) {
		thisLeaf = (Leaf*)malloc(sizeof(Leaf));
		createLeaf(thisLeaf, key, NULL, NULL, thisSprig);
		thisSprig->firstLeaf = thisLeaf;
		return;
	}
	
	int count = caliper;
	while(thisLeaf->key < key) {
		if (thisLeaf->nextLeaf != NULL) {
			thisLeaf = thisLeaf->nextLeaf;
		} else if (count == 2) {
			//reached end of sprig, keys still smaller.
			if (thisLeaf->childSprig == NULL) {
				//split and promote, because no far right sprig available
				splitPromote(thisLeaf, thisSprig, key, caliper);
				
			}
			//add this key to far right sprig because it exists
			addLeaf(thisLeaf->childSprig, key, caliper);
		} else {
			//there is room in this sprig for a new leaf
			Leaf* newLeaf = (Leaf*)malloc(sizeof(Leaf));
			createLeaf(newLeaf, key, thisLeaf, NULL, thisSprig);
			thisLeaf->nextLeaf = newLeaf;
			return;
		}
		count--;
	}
	//ran into a key too big
	//try to fit in same sprig
	if (numLeaves(thisSprig) < caliper - 1) {
		int tempKey = thisLeaf->key;
		thisLeaf->key = key;
		Leaf* newLeaf = (Leaf*)malloc(sizeof(Leaf));
		createLeaf(newLeaf, tempKey, thisLeaf, NULL, thisSprig);
		if (thisLeaf->nextLeaf != NULL) {
			thisLeaf->nextLeaf->prevLeaf = newLeaf;
			newLeaf->nextLeaf = thisLeaf->nextLeaf;
		}
		thisLeaf->nextLeaf = newLeaf;
	}
	//sprig is too full,
	else {
		splitPromote(thisLeaf, thisSprig, key, caliper);
	}
	return;
}

void splitPromote(Leaf* thisLeaf, Sprig* thisSprig, int key, int caliper) {
	//new sprig
	Sprig* newRightSprig = (Sprig*)malloc(sizeof(Sprig));
	if (thisSprig->parentSprig == NULL) {
		//need to make new sprig on top
		Sprig* newTopSprig = (Sprig*)malloc(sizeof(Sprig));
		newRightSprig->parentSprig = newTopSprig;
		thisSprig->parentSprig = newTopSprig;
	} else {
		//need to incorporate with existing upper sprig
		newRightSprig->parentSprig = thisSprig->parentSprig;
	}
	Leaf* newLeaf = (Leaf*)malloc(sizeof(Leaf));
	if (thisLeaf->nextLeaf == NULL) {
		//add leaf to end
		createLeaf(newLeaf, key, thisLeaf, NULL, newRightSprig);
		thisLeaf->nextLeaf = newLeaf;
	} else {
		createLeaf(newLeaf, key, thisLeaf->prevLeaf, thisLeaf, newRightSprig);
		thisLeaf->prevLeaf->nextLeaf = newLeaf;
		thisLeaf->prevLeaf = newLeaf;
	}
	//start at the rightmost Leaf
	while (thisLeaf->nextLeaf != NULL) {
		thisLeaf = thisLeaf->nextLeaf;
	}
	
	//then move back to split
	int count = caliper/2 - 1;
	while (count > 0) {
		//every leaf on this side of the split needs to reassociate
		thisLeaf->currSprig = newRightSprig;
		//newRightSprig needs to find its first leaf
		newRightSprig->firstLeaf = thisLeaf;
		thisLeaf = thisLeaf->prevLeaf;
		count--;
	}
	//now thisLeaf is the median
	thisLeaf->childSprig = newRightSprig;
	
	//separate from the right leaves
	if (thisLeaf->nextLeaf != NULL) {
		thisLeaf->nextLeaf->prevLeaf = NULL;
		thisLeaf->nextLeaf = NULL;
	}
	
	//bring this leaf up to the parentSprig
	addLeaf(thisSprig->parentSprig, thisLeaf->key, caliper);
	//find the leaf just before the one we just added up there
	Leaf* currLeaf = thisSprig->parentSprig->firstLeaf;
	while (currLeaf->key < thisLeaf->key) {
		currLeaf = currLeaf->nextLeaf;
	}
	//currLeaf is now one step too far right...
	if (currLeaf->prevLeaf != NULL) {
		currLeaf->prevLeaf->childSprig = thisSprig;
	} else {
		currLeaf->currSprig->leftSprig = thisSprig;
	}
	
	//free up the memory of the left behind leaf
	free(thisLeaf);
}

//file reading from zyante 9.5
Sprig* fileRead(char filename[]) {
	FILE* inFile = fopen(filename, "r");
	if( inFile == NULL ) {
		return NULL; //file read error
	}

	int caliper; //the order of the b-tree
	int key;
	fscanf(inFile, "%d", &caliper);
	
	//initialize the topmost Sprig
	Sprig* topSprig = (Sprig*)malloc(sizeof(Sprig));
	createSprig(topSprig, NULL);
	
	fscanf(inFile, "%d", &key);
	while (!feof(inFile)) {
		addLeaf(topSprig, key, caliper);
		fscanf(inFile, "%d", &key);
	}
	
	fclose(inFile);
	return topSprig; //file read worked
}

void printSprig(Sprig* thisSprig, int cursor) {
	printf(" ");
	Leaf* currLeaf = thisSprig->firstLeaf;
	while (currLeaf != NULL) {
		if (cursor == 0) printf("* ");
		printf("%d ", currLeaf->key);
		currLeaf = currLeaf->nextLeaf;
		cursor--;
	}
	if (cursor == 0) printf("*");
	printf("\n");
}

//returns the nth leaf in a sprig
Leaf* nthLeaf(Sprig* thisSprig, int n) {
	if (n==0) return NULL;
	
	Leaf* nthLeaf = thisSprig->firstLeaf;
	int i;
	for (; n>1 ; n--) {
		nthLeaf = nthLeaf->nextLeaf;
	}
	
	return nthLeaf;
}

int numLeaves(Sprig* thisSprig) {
	Leaf* nthLeaf = thisSprig->firstLeaf;
	if (nthLeaf == NULL) return -1;
	
	int i = 1;
	while (nthLeaf->nextLeaf != NULL) {
		nthLeaf = nthLeaf->nextLeaf;
		i++;
	}
	
	return i;
}

void explore(Sprig* thisSprig, int cursor, int caliper) {
	printSprig(thisSprig, cursor);

	Leaf* selectedLeaf = nthLeaf(thisSprig, cursor);

	char  keypress = 0;
	printf("Command: ");
	scanf(" %c", &keypress);

	switch (keypress) {
		case 'w':
			if (thisSprig->parentSprig == NULL) {
				printf("You are already at the top!\n");
			} else thisSprig = thisSprig->parentSprig;
			break;

		case 'a':
			if (cursor > 0) cursor--;
			break;

		case 's':
			if (cursor == 0) {
				if (thisSprig->leftSprig != NULL) {
					thisSprig = thisSprig->leftSprig;
				} else printf("No child at this leaf!\n");
			} else {
				if (selectedLeaf->childSprig != NULL) {
					thisSprig = selectedLeaf->childSprig;
				} else printf("No child at this leaf!\n");
			}
			break;

		case 'd':
			if (cursor < caliper && cursor < numLeaves(thisSprig)) cursor++;
			break;

		case 'q':
			while (thisSprig->parentSprig != NULL) {
				thisSprig = thisSprig->parentSprig;
			}
			freeTree(thisSprig);
			return;

		default:
			printf("Command not recognized. Try again.\n");
			break;
	}
	explore(thisSprig, cursor, caliper);
}

void freeTree(Sprig* thisSprig) {
	if (thisSprig == NULL) return;
	//free childSprigs first
	freeTree(thisSprig->leftSprig);
	
	int i = numLeaves(thisSprig);
	Leaf* curr = thisSprig->firstLeaf;
	for (; i>0; i--) {
		freeTree(curr->childSprig);
		curr = curr->nextLeaf;
	}
	
	//then free leaves in own scope
	curr = thisSprig->firstLeaf;
	Leaf* next = curr->nextLeaf;
	for(i=numLeaves(thisSprig); i>0; i--) {
		free(curr);
		curr = next;
		if (curr != NULL) next = curr->nextLeaf;
	}
	
	//then free self
	free(thisSprig);
	
	return;
}

void main() {
	//get filename from user and attempt to read file
	char filename[50] = "";

	printf("file:  ");
	scanf("%s", filename);
	Sprig* topSprig = fileRead(filename);
	if (topSprig != NULL) {
		//read worked
		//do stuff
		explore(topSprig, 0, 8);
		return;
	} else {
		//read failed. try again?
		if (strcmp(filename, "q") != 0) {
			printf("read failed, try again (or 'q' to quit)\n");
			main();
		}
	}
}
