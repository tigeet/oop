using Isu.Entities;

namespace Isu.Services;
public class StudentIdFactory
{
    private static int startId = 100000;
    private Node head = new Node(null, startId, true);

    public StudentIdFactory() { }

    public int GetNewId()
    {
        int id = head.GetValue();

        if (head.GetHasNext())
        {
            var next = new Node(null, id + 1, true);
            head = next;
        }
        else
        {
            head = head.GetNext() !;
        }

        return id;
    }

    public void ReturnId(Student student)
    {
        var prev = new Node(head, student.GetStudentId(), false);
        head = prev;
    }

    private class Node
    {
        private Node? next;
        private int value;
        private bool hasNext;

        public Node(Node? next, int value, bool hasNext)
        {
            this.next = next;
            this.value = value;
            this.hasNext = hasNext;
        }

        public Node? GetNext()
        {
            return next;
        }

        public bool GetHasNext()
        {
            return hasNext;
        }

        public int GetValue()
        {
            return value;
        }
    }
}
