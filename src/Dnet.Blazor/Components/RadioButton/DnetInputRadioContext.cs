using Microsoft.AspNetCore.Components;

namespace Dnet.Blazor.Components.RadioButton
{
    /// <summary>
    /// Instantiates a new <see cref="InputRadioContext" />.
    /// </summary>
    /// <param name="parentContext">The parent <see cref="InputRadioContext" />.</param>
    /// <param name="groupName">The name of the input radio group.</param>
    /// <param name="currentValue">The current selected value in the input radio group.</param>
    /// <param name="fieldClass">The css class indicating the validation state of input radio elements.</param>
    /// <param name="changeEventCallback">The event callback to be invoked when the selected value is changed.</param>
    internal class DnetInputRadioContext(
        DnetInputRadioContext? parentContext,
        string groupName,
        object? currentValue,
        string fieldClass,
        EventCallback<ChangeEventArgs> changeEventCallback)
    {

        /// <summary>
        /// Gets the name of the input radio group.
        /// </summary>
        public string GroupName { get; } = groupName;

        /// <summary>
        /// Gets the current selected value in the input radio group.
        /// </summary>
        public object? CurrentValue { get; } = currentValue;

        /// <summary>
        /// Gets a css class indicating the validation state of input radio elements.
        /// </summary>
        public string FieldClass { get; } = fieldClass;

        /// <summary>
        /// Gets the event callback to be invoked when the selected value is changed.
        /// </summary>
        public EventCallback<ChangeEventArgs> ChangeEventCallback { get; } = changeEventCallback;

        /// <summary>
        /// Finds an <see cref="InputRadioContext"/> in the context's ancestors with the matching <paramref name="groupName"/>.
        /// </summary>
        /// <param name="groupName">The group name of the ancestor <see cref="InputRadioContext"/>.</param>
        /// <returns>The <see cref="InputRadioContext"/>, or <c>null</c> if none was found.</returns>
        public DnetInputRadioContext? FindContextInAncestors(string groupName)
            => string.Equals(GroupName, groupName) ? this : parentContext?.FindContextInAncestors(groupName);
    }
}
