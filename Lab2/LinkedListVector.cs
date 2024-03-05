namespace Lab2
{
    public class LinkedListVector
    {
        private Node? head;

        public LinkedListVector(int length)
        {
            head = new Node();
            var node = head;

            for (int i = 1; i < length; i++)
            {
                node.next = new Node();
                node = node.next;
            }

            Length = length;
        }

        public LinkedListVector() : this(5) { }

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                var node = GetNodeByIndex(index - 1);
                return node.value;
            }
            set
            {
                var node = GetNodeByIndex(index - 1);
                node.value = value;
            }
        }

        public double GetNorm()
        {
            int sum = 0;

            var node = head;

            while (node != null)
            {
                sum += node.value * node.value;
                node = node.next;
            }

            return Math.Sqrt(sum);
        }

        public void InsertStart(int value)
        {
            var node = new Node(value, head);
            head = node;
            Length++;
        }

        public void DeleteStart()
        {
            if (Length == 0)
            {
                return;
            }
            head = head?.next;
            Length--;
        }

        public void InsertEnd(int value)
        {
            if (head == null)
            {
                head = new Node(value);
            }
            else
            {
                // var node = head;
                // while(node.next != null) {
                //     node = node.next;
                // }
                // node.next = new Node(value);
                var node = GetNodeByIndex(Length - 1);
                node.next = new Node(value);
            }
            Length++;
        }

        public void DeleteEnd()
        {

            if (head == null)
            {
                return;
            }
            if (head.next == null)
            {
                head = null;
                Length--;
                return;
            }
            var node = GetNodeByIndex(Length - 2);
            node.next = null;
            Length--;
        }

        public void InsertByIndex(int index, int value)
        {
            if (index == Length)
            {
                var prevCurrNode = GetNodeByIndex(index - 2);
                prevCurrNode.next = new Node(value, prevCurrNode.next);
                Length++;
            }
            else if (index == 1)
            {
                InsertStart(value);
            }
            else
            {
                var prevCurrNode = GetNodeByIndex(index - 2);
                prevCurrNode.next = new Node(value, prevCurrNode.next);
                Length++;
            }
        }

        public void DeleteByIndex(int index)
        {
            if (index < 1 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == Length)
            {
                DeleteEnd();
            }
            else if (index == 1)
            {
                DeleteStart();
            }
            else
            {
                var prevCurrNode = GetNodeByIndex(index - 2);
                prevCurrNode.next = prevCurrNode.next.next;
                Length--;
            }
        }

        public override string ToString()
        {
            if (Length == 0)
            {
                return "{ }";
            }
            string res = "{ ";
            for (int i = 0; i < Length - 1; i++)
            {
                res += this[i + 1] + ", ";
            }
            return res + this[Length] + " }";
        }

        private Node GetNodeByIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new IndexOutOfRangeException();
            }

            var node = head;

            for (int i = 0; i < index; i++)
            {
                node = node?.next;
            }

            return node;
        }

        private class Node
        {
            public int value;
            public Node? next;

            public Node(int nodeValue = 0, Node? nextNode = null)
            {
                value = nodeValue;
                next = nextNode;
            }
        }
    }
}