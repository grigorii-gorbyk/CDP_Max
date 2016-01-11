Resilience and Availability

<b>Home Work</b>
Please download simple asp.net application from https://git.epam.com/maksym_savchenko/resilience-and-
availability-cdp-homework.git (Please ask your mentor on how to do this more effective (Fork, Merge Request, etc.))

<b>Base topics:</b>
<b>1. Storage Locking: Create separate denormalized tables for each page. 
Create separate DbContext for them. Target read operation to these new tables. Create operation has to work with original 
HeroesContext (for data consistency) as well as update all needed denormalized tables.
</b>

<b>Branch:</b>StorageLocking

<b>Description:</b>
New HeroesReadContext created with following entities: 
HeroRead (duplication of table for writing)
PersonRead (duplication of table for writing)
TopHero
LatestHero

All creation operations writes all data to all tables.
Any read operation uses only entities of HeroesReadContext.

<b>2. Caching: Add cache to all read operations. Think of reasonable cache expiration time to make minimal 
but useful timeout for this application.</b>

<b>Branch:</b>Caching

<b>Description:</b> 
Simple in-memory Glav.CacheAdapter is used.
Cache time was set to infinite value as there is no sence to update the cache.
On any create operation the depending caches have been invalidated.

<b>3. Asynchronous processing: Make all MVC controllers asynchronous</b>

<b>Branch:</b>AsyncProcessing

<b>Description:</b> Just create all controllers actions async and put time-consuming code (database queries) in tasks bodies.


<b>4. Fault tolerance: protect your DB operations using Circuit Breaker from Polly library</b>

<b>Branch:</b>FaultTolerance

<b>Description:</b> Using Polly package crate policies for different actions set: DAL Policy , 
Controller code execution Policy and View Rendering Policy.
Separate endpoint (action with exception) to display custom error page created.

<b>Advanced topics:</b>

<b>1. Caching: Use some distributed caching system instead of inproc cache for task 2 of Base topics.</b>

<b>2. Redundancy ready: Move session storage of an application to some distributed caching system</b>

<b>Branch:</b>No branch

<b>Description:</b> Did nothing. Just have found that it is NCache package must be installed. It enables to implement all these features.

<b>Extra Advanced topics:</b>

<b>1. Decoupling: Connect web layer of hero promotion action with db layer via some queue system. (MSMQ could be used.)</b>

<b>Branch:</b>MSMQ

<b>Description:</b>

(1)Enable MSMQ on my workstation and create the separate private queue

(2)Create Read/Write Services

(3)In WriteService on any entity createion the separate queue is created

(4)To omit the creation the separate queue message reading process I just created the fake queue reader. It runs async after any queue message sent.

(5) On the messages reading the new data being inserted into database.
