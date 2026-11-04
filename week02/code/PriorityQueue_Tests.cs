using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2: Tests cover enqueue order, highest priority, ties, removal, and empty queue.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add two items in arrival order with different priorities.
    // Expected Result: Both items appear in insertion order in ToString().
    // Defect(s) Found: None in Enqueue; it already appends to the list.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 5);
        Assert.AreEqual("[First (Pri:1), Second (Pri:5)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Highest-priority item is the final item in the queue.
    // Expected Result: Dequeue returns "Last" and removes it.
    // Defect(s) Found: Search loop originally skipped the final item; Dequeue also failed to remove it.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Middle", 3);
        priorityQueue.Enqueue("Last", 9);
        Assert.AreEqual("Last", priorityQueue.Dequeue());
        Assert.AreEqual("[First (Pri:1), Middle (Pri:3)]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Multiple items share the highest priority.
    // Expected Result: Earlier item wins the tie; both are removed in FIFO order.
    // Defect(s) Found: Using >= selected the later equal-priority item; missing RemoveAt kept items queued.
    public void TestPriorityQueue_TiesUseFifo()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstHigh", 8);
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("SecondHigh", 8);
        Assert.AreEqual("FirstHigh", priorityQueue.Dequeue());
        Assert.AreEqual("SecondHigh", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
        Assert.AreEqual("[]", priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue the only item and then try again.
    // Expected Result: First call returns the value; second throws InvalidOperationException with exact message.
    // Defect(s) Found: Dequeue originally never removed the item, preventing the empty-queue error.
    public void TestPriorityQueue_RemovalAndEmpty()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Only", 2);
        Assert.AreEqual("Only", priorityQueue.Dequeue());
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Dequeue from an initially empty queue.
    // Expected Result: InvalidOperationException with exact required message.
    // Defect(s) Found: None; the original empty-queue guard was already correct.
    public void TestPriorityQueue_InitiallyEmpty()
    {
        var priorityQueue = new PriorityQueue();
        var exception = Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
