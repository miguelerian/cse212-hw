using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add Apple(1), Banana (3), and Orange (2)
    // Expected Result: Banana, Orange, Apple
    // Defect(s) Found: Dequeue doesn't remove items.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 3);
        priorityQueue.Enqueue("Orange", 2);

        Assert.AreEqual("Banana", priorityQueue.Dequeue());
        Assert.AreEqual("Orange", priorityQueue.Dequeue());
        Assert.AreEqual("Apple", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add Cat(5), Dog(5), and Bird(5)
    // Expected Result: Cat, Dog, Bird
    // Defect(s) Found: Equal priorities select the last item instead of the first.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Cat", 5);
        priorityQueue.Enqueue("Dog", 5);
        priorityQueue.Enqueue("Bird", 5);

        Assert.AreEqual("Cat", priorityQueue.Dequeue());
        Assert.AreEqual("Dog", priorityQueue.Dequeue());
        Assert.AreEqual("Bird", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add A (2), B (5), C (5), and D (1).
    // Expected Result: B, C, A, D.
    // Defect(s) Found: 	Equal priorities select the last item; the last queue element is also skipped.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 5);
        priorityQueue.Enqueue("D", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: Empty queue exception works correctly.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()
        );

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}