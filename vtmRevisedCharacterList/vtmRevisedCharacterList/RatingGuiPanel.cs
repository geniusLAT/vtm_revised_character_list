using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList
{
    internal class RatingGuiPanel
    {
        public required ARating rating { get; set; }

        public required Panel Panel {  get; set; }

        public required Label Label {  get; set; }

        public required RadioButton[] RadioButtons { get; set; }

        public required NumericUpDown Numeric {  get; set; }

    }
}
