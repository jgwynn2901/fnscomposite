using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FnsComposite
{
    /// <summary>
    /// Returns a list of element names that qualify based on supplied predicate.
    /// </summary>
    public class ConditionalVisitor : VisitorBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected Predicate<CompositeBase> Predicate;

        private readonly List<string> _results = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalVisitor"/> class.
        /// </summary>
        /// <param name="p">The p.</param>
        public ConditionalVisitor (Predicate<CompositeBase> p)
        {
            Predicate = p;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalVisitor"/> class.
        /// </summary>
        protected ConditionalVisitor()
        {}

        /// <summary>
        /// Visits the specified element.
        /// </summary>
        /// <param name="element"></param>
        public override void Visit(CompositeBase element)
        {
            if(Predicate(element))
                _results.Add(element.ParentPathSansRoot());

            base.Visit(element);
        }

        /// <summary>
        /// Gets the results.
        /// </summary>
        public List<string> Results { get { return _results; } }
    }

    /// <summary>
    /// returns a list of element names that match the regular expression.
    /// </summary>
    public class NameExpressionVisitor : ConditionalVisitor
    {
        private readonly Regex _eval;
        /// <summary>
        /// Initializes a new instance of the <see cref="NameExpressionVisitor"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public NameExpressionVisitor(string expression)
        {
            _eval = new Regex(expression);
            Predicate = c => c.IsLeaf && _eval.IsMatch(c.FullName);
        }
     }
}
