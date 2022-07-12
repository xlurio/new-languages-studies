# Collections and Data Structures

## Introduction

This is where are the collections and data structures usage studies. Similar data can often be stored in together and manipulated as a collection. To do it, in C#, you can use the System.Array class, or the classes in System.Collections.Generic, System.Collections.Concurrent and System.Collections.Immutable namespaces.


## Common Collections Features

All collections provide methods to add, remove or finding items in it. In addition, all collections the directly of indirectly implement ICollection or ICollection&lt;T&lt; interfaces share the ability to enumerate the collection and to copy contents to an array. Many of them still can have the Capacity and Count properties, consistent lower bound and synchronization for access from multiple threads.


### Ability To Enumerate The Collection

.NET collections either implement System.Collections.IEnumerable or System.Collections.Generic.IEnumerable&lt;T&lt;, enabling being iterated through. An enumerator can be thought as a movable pointer to any element in the collection.

The foreach, in and the For Each...Next statements use the enumerator exposed by GetEnumerator method and hide the complexity of manipulating the enumerator.

IEnumerable&lt;T&lt; is considered a querable type and can be queried with LINQ. LINQ queries provide a common pattern to access data and can improve performance.


### Ability To Copy Contents To An Array

All collections can be copied to an Array using the CopyTo method. However, the order of the elements is determined by the enumerator and the resulting array is always one-dimension and with lower bound of zero.


### Capacity and Count Properties

Capacity is the number of elements a Collection can contain. Count is the number of elements it currently contains. Some collections hide the count and capacity properties.

Most collections automatically expand its capacity when it's current capacity is reached. The memory is reallocated and the elements are copied from the old collection to a new. This may cause affect negatively the performance. To avoid losing performance a initial capacity should always be passed when it is possible.


### A Consistent Lower Bound

The lower bound is the index of the first element in the collection. All indexed collection in System.Collections namespaces have a lower bound of zero. Arrays have a lower bound of zero by default, but is can be set using Array.CreateInstance.


### Synchronization For Access From Multiple Threads

All collections in System.Collections.Concurrent namespace and immutable collections are Thread-Safe.


## Available Collections

The table below shows all native and recommended collections in C#:

<table>
    <thead>
        <th>I Want To...</th>
        <th>Generic Collections</th>
        <th>Thread-safe Collections</th>
    </thead>
    <tbody>
        <tr>
            <td>Store item as key/value pairs for quick lookup by key</td>
            <td>Dictionary&lt;Tkey&lt;&lt;TValue&lt;</td>
            <td>
                ConcurrentDictionary&lt;Tkey&lt;&lt;TValue&lt;<br/> ReadOnlyDictionary&lt;Tkey&lt;&lt;TValue&lt;<br/>  ImmutableDictionary&lt;Tkey&lt;&lt;TValue&lt;
            </td>
        </tr>
        <tr>
            <td>Access items by index</td>
            <td>List&lt;T&lt;</td>
            <td>
                ImmutableList&lt;T&lt;<br/>
                ImmutableArray&lt;T&lt;
            </td>
        </tr>
        <tr>
            <td>Use items first-in-first-out(FIFO)</td>
            <td>Queue&lt;T&lt;</td>
            <td>
                ConcurrentQueue&lt;T&lt;<br/>
                ImmutableQueue&lt;T&lt;
            </td>
        </tr>
        <tr>
            <td>Use data last-in-first-out</td>
            <td>Stack&lt;T&lt;</td>
            <td>
                ConcurrentStack&lt;T&lt;<br/>
                ImmutableStack&lt;T&lt;
            </td>
        </tr>
        <tr>
            <td>Access items sequentially</td>
            <td>LinkedList&lt;T&lt;</td>
            <td>No recommendation</td>
        </tr>
        <tr>
            <td>Receive notifications when elements are added or removed</td>
            <td>ObservableCollection&lt;T&lt;</td>
            <td>No recommendation</td>
        </tr>
        <tr>
            <td>A sorted collection</td>
            <td>SortedList&lt;Tkey&lt;&lt;TValue&lt;</td>
            <td>
                ImmutableSortedDictionary&lt;Tkey&lt;&lt;TValue&lt;<br/>
                ImmutableSortedSet&lt;T&lt;
            </td>
        </tr>
        <tr>
            <td>A set for mathematical functions</td>
            <td>
                Hashset&lt;T&lt;<br/>
                SortedSet&lt;T&lt;
            </td>
            <td>
                ImmutableHashset&lt;T&lt;<br/>
                ImmutableSortedSet&lt;T&lt;
            </td>
        </tr>
    </tbody>
</table>


## Algorithm Complexity of Collections

When choosing a collection class, it is worth considering the tradeoffs in performance. The table below shows how various mutable colletion classes perform against its immutable correspondent:


<table>
    <thead>
        <tr>
            <th>Mutable</th>
            <th>Amortized</th>
            <th>Worst Case</th>
            <th>Immutable</th>
            <th>Complexity</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Stack&lt;T&gt;.Push</td>
            <td>O(1)</td>
            <td>O(n)</td>
            <td>ImmutableStack&lt;T&gt;.Push</td>
            <td>O(1)</td>
        </tr>
        <tr>
            <td>Queue&lt;T&gt;.Enqueue</td>
            <td>O(1)</td>
            <td>O(n)</td>
            <td>ImmutableQueue&lt;T&gt;.Enqueue</td>
            <td>O(1)</td>
        </tr>
        <tr>
            <td>List&lt;T&gt;.Add</td>
            <td>O(1)</td>
            <td>O(n)</td>
            <td>ImmutableList&lt;T&gt;.Add</td>
            <td>O(log n)</td>
        </tr>
        <tr>
            <td>List&lt;T&gt;.Item[Int32]</td>
            <td>O(1)</td>
            <td>O(1)</td>
            <td>ImmutableList&lt;T&gt;.Item[Int32]</td>
            <td>O(log n)</td>
        </tr>
        <tr>
            <td>List&lt;T&gt;.Enumerator</td>
            <td>O(n)</td>
            <td>O(n)</td>
            <td>ImmutableList&lt;T&gt;.Enumerator</td>
            <td>O(n)</td>
        </tr>
        <tr>
            <td>HashSet&lt;T&gt;.Add, lookup</td>
            <td>O(1)</td>
            <td>O(n)</td>
            <td>ImmutableHashSet&lt;T&gt;.Add</td>
            <td>O(log n)</td>
        </tr>
        <tr>
            <td>SortedSet&lt;T&gt;.Add</td>
            <td>O(log n)</td>
            <td>O(n)</td>
            <td>ImmutableSortedSet&lt;T&gt;.Add</td>
            <td>O(log n)</td>
        </tr>
        <tr>
            <td>Dictionary&lt;T&gt;.Add</td>
            <td>O(1)</td>
            <td>O(n)</td>
            <td>ImmutableDictionary&lt;T&gt;.Add</td>
            <td>O(log n)</td>
        </tr>
        <tr>
            <td>Dictionary&lt;T&gt; lookup</td>
            <td>O(1)</td>
            <td>O(1) – or strictly O(n)</td>
            <td>ImmutableDictionary&lt;T&gt; lookup</td>
            <td>O(log n)</td>
        </tr>
        <tr>
            <td>SortedDictionary&lt;T&gt;.Add</td>
            <td>O(log n)</td>
            <td>O(n log n)</td>
            <td>ImmutableSortedDictionary&lt;T&gt;.Add</td>
            <td>O(log n)</td>
        </tr>
    </tbody>
</table>

A List&lt;T&lt; can be efficiently enumerated using either a for loop or a foreach loop. An ImmutableList&lt;T&lt;, however, performs better using foreach, because it uses binary tree to store its data intead of a simple array like List&lt;T&lt; uses.

## LINQ

LINQ was created to make queries from different data sources using the same language. It consists of three operations: obtain data source, create the query, execute the query.

### Obtain Data Source

With LINQ you can extract data from three different data source type: C# queryable type, SQL and XML. 

With queryable types no special treatment and they can receive the query directly:

´´´
static void Main() {
    int[] numbers = new int[7] {0, 1, 2, 3, 4, 5, 6};

    var numQuery =
        from num in numbers
        where (num % 2) == 0
        select num;

    foreach (int num in numQuery) {
        Console.WriteLine($"{num}");
    }

    # Output: 0
    # Output: 2
    # Output: 4
    # Output: 6
}
´´´

With SQL and XML though, you need to modify them into a queryable type. 

The XML needs to be loaded into a XElement:

´´´
XElement contact = XElement.Load(@"c:\myContactList.xml");
´´´

For SQL you first need to create an ORM and write the queries against the model objects:

´´´
Northwnd db = new Northwnd(@"c:\northwnd.mdf");

IQueryable&lt;Customer&lt; custQuery = 
    from cust in db.Customers
    where cust.City = "London"
    select cust;
´´´


### Create The Query
The query contains three clauses: from, where and select. from specifies the data source, where specifies the pattern and select specifies the return:

´´´
IQueryable&lt;Customer&lt; custQuery = 
    from cust in db.Customers
    where cust.City = "London"
    select cust;
´´´


### Execute The Query

To execute the query you only need to iterate the query using a foreach loop:

´´´
foreach (int num in numQuery) {
    Console.Write("{0,1} ", num);
}
´´´


### Forcing execution

By default, the query is not executed until it is iterated. To force immediate execution and cache its results you can use the ToList or ToArray methods:

´´´
List<int> numQuery2 =
    (from num in numbers
     where (num % 2) == 0
     select num).ToList();
´´´