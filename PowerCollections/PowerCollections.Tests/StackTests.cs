using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wintellect.PowerCollections;

namespace PowerCollections.Tests
{
    [TestClass]
    public class StackTestscs
    {
        [TestMethod]
        public void Сonstructor_normal_stack_creation_with_constructor_check_capacity_and_count_is_zero()
        {
            Stack<string> stack = new Stack<string>(5);
            Assert.AreEqual(4, stack.Count);
            Assert.AreEqual(4, stack.Capacity);
        }

        [TestMethod]
        public void Stack_count_check_that_stack_count_is_equal_to_the_number_of_added_elements()
        {
            Stack<string> stack = new Stack<string>(5);
            stack.Push("Hello");
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void Stack_count_check_that_stack_count_is_zero_when_pushing_one_element_further_removing_it_from_the_top()
        {
            Stack<string> stack = new Stack<string>(1);
            stack.Push("Hello");
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void Stack_count_check_that_stack_count_not_zero_when_pushing_two_elements_further_removing_one_from_the_top()
        {
            Stack<string> stack = new Stack<string>(2);
            stack.Push("Hello");
            stack.Push("Hello");
            stack.Pop();
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void Push_add_one_element_to_the_stack_check_that_the_top_element_is_equal_to_the_added_one_and_the_count_is_equal_to_one()
        {
            Stack<int> stack = new Stack<int>(2);
            stack.Push(5);
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(5, stack.Top());
        }

        [TestMethod]
        public void Pop_an_element_from_the_stack_check_that_the_given_element_is_equal_to_the_added_one_and_count_is_zero()
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(1);
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void Pop_an_element_from_the_stack_check_that_the_given_element_is_equal_to_the_last_one_added_and_the_count_has_decreased_by_one()
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Count);
        }

        [TestMethod]
        public void Top_element_from_the_stack_check_that_it_is_equal_to_the_added_element_and_count_has_not_changed()
        {
            Stack<int> stack = new Stack<int>(5);
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
            Assert.AreEqual(1, stack.Top());
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void Enumerator_get_enumerator_go_from_top_to_bottom()
        {
            Stack<string> stack = new Stack<string>(5);
            string[] duplicatedStack = new string[] { "Hello", "Good", "Job", "My", "friend" };
            foreach (string item in duplicatedStack)
            {
                stack.Push(item);
            }
            string[] stackItems = stack.ToArray();
            Array.Reverse(stackItems);
            CollectionAssert.AreEqual(stackItems, duplicatedStack);
        }

        [TestMethod]
        public void Enumerator_get_enumerator_from_stack_without_elements()
        {
            Stack<string> stack = new Stack<string>(3);
            IEnumerator numerator = stack.GetEnumerator();
            Assert.AreEqual(false, numerator.MoveNext());
        }

        [TestMethod]
        public void Enumerator_get_enumerator_from_stack_with_element()
        {
            Stack<string> stack = new Stack<string>(1);
            IEnumerator enumerator = stack.GetEnumerator();
            stack.Push("Hello");
            enumerator.MoveNext();
            Assert.AreEqual(false, enumerator.MoveNext());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack capacity must be greater than zero")]
        public void Сonstructor_check_exception_stack_creation_with_constructor_with_capacity_zero()
        {
            Stack<string> stack = new Stack<string>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack capacity must be greater than zero")]
        public void Сonstructor_check_exception_stack_creation_with_constructor_with_capacity_less_than_zero()
        {
            Stack<string> stack = new Stack<string>(-5);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack is full.Unable to add element")]
        public void Push_check_exception_with_push_more_elements_than_capacity()
        {
            Stack<string> stack = new Stack<string>(5);
            stack.Push("Hello");
            stack.Push("Good");
            stack.Push("Job");
            stack.Push("Good");
            stack.Push("Good");
            Assert.AreEqual(5, stack.Count);
            Assert.AreEqual("Good", stack.Top());
            stack.Push("Good");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack empty")]
        public void Pop_check_exception_with_pop_element_from_empty_stack()
        {
            Stack<string> stack = new Stack<string>(2);
            stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Stack empty")]
        public void Top_check_exception_with_top_element_from_empty_stack()
        {
            Stack<string> stack = new Stack<string>(2);
            stack.Top();
        }

    }
}
