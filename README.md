# CompanyStructuredSample
This project is designed on architecture that comes as follow:

![alt text](https://github.com/matucs/CompanyStructuredSample/blob/master/Common/resources/arch.PNG)

	
Database has only one table called Node table and it includes properties such as key (as Primary key), name, and parentId (Foreign key).This table is self-related via parentId. For data persistence I will use Entity framework
REST APIs include 4 services that are as follow:
1.	GetAllChildren (parentId) with URL ...
This service will show all children and descendant of a node with Id = parentId and gets parentId as its input and the output will be ICollection<Node>. This service calls HttpGet method.
For better performance I used several methods such as 
•	Recursive function
•	Multi-threading
•	Using of CTE query that finally this option used in my project.
•	I also used a query to populate Node table. I inserted about 100000 dummy data in Node table and tested this API (GetAllChildren) with an ordinary laptop. The performance was good for this amount of data.
2.	ChangeCurrentParent(nodeId , newParentId) with URL …
This service will change parent of the node with Id = nodeId and the response will be HttpMessage that shows the response message was successful or unsuccessful. This service calls HttpPost method
3.	GetRoot() with URL
This service shows the Root node as its response. It doesn’t have any input parameter. This service calls HttpGet method.
It is mentionable root node is unique all over tree so I decided to put root definition as a service not as node feature. If I put it as node feature it would use memory.
4.	GetHeight(nodeId) with URL 
This service will give height of the node with Id = nodeId and the response will be height of this node which is an integer. This service calls HttpGet method.
This API has complexity = O (Log n). Because in the worst case you want to know the height of last child of tree and it has to traverse tree to get root node to count its height.
