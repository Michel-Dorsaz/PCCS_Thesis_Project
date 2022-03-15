namespace BLL
{
    /// <summary>
    /// This class is used to display MessageBoxes to the user.
    /// <para/>
    /// This class is just a simplified access to the MessageBox class by implementing a
    /// method for each type of message.
    /// </summary>
    public static class MessagesManager
    {
        /// <summary>
        /// A warning message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult WarningMessage(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(
                    message,
                    "Warning",
                    buttons,
                    MessageBoxIcon.Warning
                    );
        }

        /// <summary>
        /// An information message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult InfoMessage(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(
                message,
                "Information",
                buttons,
                MessageBoxIcon.Information
                );
        }

        /// <summary>
        /// A question message whose title can be modified.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static DialogResult QuestionMessage(string title, string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(
                message,
                title,
                buttons,
                MessageBoxIcon.Question
                );
        }
    }
}
