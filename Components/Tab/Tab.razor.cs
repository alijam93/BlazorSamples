using Microsoft.AspNetCore.Components;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSamples.Components.Tab
{
    public partial class Tab
    {

        /// <summary>
        /// List of <see cref="TabStep"/> added to the Tab
        /// </summary>
        protected internal List<TabStep> Steps = new();

        /// <summary>
        /// The control Id
        /// </summary>
        [Parameter]
        public string Id { get; set; } 

        /// <summary>
        /// The ChildContent container for <see cref="TabStep"/>
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// The Active <see cref="TabStep"/>
        /// </summary>
        [Parameter] public TabStep ActiveStep { get; set; }

        /// <summary>
        /// The Index number of the <see cref="ActiveStep"/>
        /// </summary>
        [Parameter] public int ActiveStepIx { get; set; }

        /// <summary>
        /// Determines whether the Tab is in the last step
        /// </summary>

        public bool IsLastStep { get; set; }

        /// <summary>
        /// Sets the <see cref="ActiveStep"/> to the previous Index
        /// </summary>

        protected internal void GoBack()
        {
            if (ActiveStepIx > 0)
                SetActive(Steps[ActiveStepIx - 1]);
        }

        /// <summary>
        /// Sets the <see cref="ActiveStep"/> to the next Index
        /// </summary>
        protected internal void GoNext()
        {
            if (ActiveStepIx < Steps.Count - 1)
                SetActive(Steps[(Steps.IndexOf(ActiveStep) + 1)]);
        }

        /// <summary>
        /// Populates the <see cref="ActiveStep"/> the Sets the passed in <see cref="TabStep"/> instance as the
        /// </summary>
        /// <param name="step">The TabStep</param>

        protected internal void SetActive(TabStep step)
        {
            ActiveStep = step ?? throw new ArgumentNullException(nameof(step));

            ActiveStepIx = StepsIndex(step);
            if (ActiveStepIx == Steps.Count - 1)
                IsLastStep = true;
            else
                IsLastStep = false;
            Console.WriteLine($"SetActive() => ActiveStepIx:{ActiveStepIx}, Steps.Count-1: {Steps.Count - 1}," +
                $"ActiveStep:{ActiveStep}, IsLastStep:{IsLastStep}, ");
        }

        /// <summary>
        /// Retrieves the index of the current <see cref="TabStep"/> in the Step List
        /// </summary>
        /// <param name="step">The TabStep</param>
        /// <returns></returns>
        public int StepsIndex(TabStep step) => StepsIndexInternal(step);
        protected int StepsIndexInternal(TabStep step)
        {
            if (step == null)
                throw new ArgumentNullException(nameof(step));

            return Steps.IndexOf(step);
        }
        /// <summary>
        /// Adds a <see cref="TabStep"/> to the TabSteps list
        /// </summary>
        /// <param name="step"></param>
        protected internal void AddStep(TabStep step)
        {
            Steps.Add(step);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                SetActive(Steps[0]);
                StateHasChanged();
            }
        }
    }
}
