using vtmRevisedCharacterListEntities;

namespace vtmRevisedCharacterList
{
    internal class MeritGuiPanel
    {
        public required MeritEntity rating { get; set; }

        public required Panel Panel {  get; set; }

        public required Label Label {  get; set; }

        public required Button Button { get; set; }

        public CheckBox? CheckBox { get; set; }

    }
}
