This is where i plan out my code before i actually write any code:

 im planning out the models

 for the user, i have decided to have a database but no auth since its a project and most people who want to check out a project just want to see the main features, auth would be a waste of time.

 The userflow should look something like :

Homepage -> Enter UserName -> Create room || Join room -> Diagram editor

Design is very human, lol.

so the user model will look like 

User{
int id
string UserName
datetime created at
}

then we will need a room model, users can create or join a room.
Each room will have its id, the usernames of the users present in the room and the date time it was created

so it should look like 

Room {
int roomId
user = Users[ ]
date time created at
string roomCode
}
//change made here at 18:42pm (room code changed from an integer to a string)

the users will hold the List of users available in the room

We will have a create and join room Dto

create room dto {
    string username (required)
}

join room dto {
    string username
    string code (required)
    int RoomId
}

now for the stars of the show the nodes and edges:

nodes are the boxes that contain our information while edges are the lines that connect them together

for the nodes we will have things like the position, the height, the width, the colour, the shape and the id
for the edges we have the id of the source node and the connected target node , the room id and the id of that edge

so it should look something like

node {
    int id
    int roomId
    int height
    int width
    int color
    string type
    int positionx
    int position y
}

edges {
    int id
     int roomId
    int sourceNodeId
    int TargetNode id 
}


For realtime communication i will be using SignalR

api request(drag and drop or move node) -> events get sent -> signal r hub -> database updated -> everyone sees 


In real time connections i will be using signalR

ive made the join room
create node
move node
delete node
create edge
delete edge 
real time cursor 

// TODO: Research on proper ways to leave a room in signalr
