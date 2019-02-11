# CompanyStructuredSample

We in Amazing Co need to model how our company is structured so we can do awesome stuff.

We have a root node (only one) and several children nodes,each one with its own children as well. It's a tree-based structure. 


Something like:


        root
       / \
      a b
      |
      c


We need two HTTP APIs that will serve the two basic operations:


1) Get all children nodes of a given node (the given node can be anyone in the tree structure).
2) Change the parent node of a given node (the given node can be anyone in the tree structure).
They need to answer quickly, even with tons of nodes. Also,we can't afford to lose this information, so some sort of persistence is required.


Each node should have the following info:


1) node identification
2) who is the parent node
3) who is the root node
4) the height of the node. In the above example,height(root) = 0 and height(a) == 1.

To deal with to this problem I make a code to find a solution even with tones of nodes.
This project is designed on architecture that comes as follow:

![alt text](https://github.com/matucs/CompanyStructuredSample/blob/master/Common/resources/arch.PNG)

There are 4 important projects in this code, first is Repository project as a data access to deal with database through Entity Framework as a ORM , Second is Logic to handle logic and communicate with Repository and third is Web API project as a http API to provide services for consumers and a sample MVC consumer project to consume Web API services by HTTP request with different methods like HTTPPOST and HTTPGET.
This code is use Docker and Docker-compose with 3 containers: clientwebapi_consumer, companystructured.webapi, SQL-Express which are communicate with each other on a virtual Docker network.
Database is used in the project is Microsoft SQL Express and  has only a table called Node and it includes properties such as key (as Primary key), name, and parentId (Foreign key).This table is self-related via parentId. 
REST APIs include 4 services that are as follow:
1.	GetAllChildren (nodeid) with URL is built in Docker: http://companystructured.webapi/api/Hierarchy/nodeid
This service will show all children and descendant of a node with I nodeid and and the output would be ICollection<Node>. This service uses HttpGet method.
To reach better performance I have tested several ways such as 
•	Recursive function
•	Multi-threading
•	Using of CTE query.
 Finally CTE query is used in my project.
I also have used a query to populate dummy data to Node table as a test [The query is called Populatedata_dbo.Node.sql and it is in root folder of the project and you can use it]. I’ve inserted about 100000 dummy data in Node table and tested this API (GetAllChildren) with an ordinary laptop. The performance was good for this amount of data.
2.	ChangeCurrentParent(nodeId , newParentId) with URL is built in Docker: http://companystructured.webapi/api/changeparent
This service will change parent of the node and the response will be HttpMessage that shows the response message was successful or not. This service uses HttpPost method
3.	GetRoot() with URL is built in Docker: http://companystructured.webapi/api/Root
This service shows the Root node as its response. It doesn’t have any input parameter. This service uses HttpGet method.
It is mentionable root node is unique all over tree so I decided to put root definition as a service not as node feature. If I put it as node feature it would use memory.
4.	GetHeight(nodeId) with URL is built in Docker: http://companystructured.webapi/api/Height/nodeid
This service will give height of the node with nodeId and the response will be height of this node which is an integer. This service uses HttpGet method.
This API has time complexity = O (Log n). Because in the worst case you want to know the height of last child of tree and it has to traverse tree to get root node to count its height. In case of performance I use CTE query agine to get height and it works fine even for a million of nodes easily.
