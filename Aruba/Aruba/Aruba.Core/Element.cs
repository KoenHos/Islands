namespace Aruba.Core
{
    public class Element
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public ElementType Type { get; set; }
    }


        public enum ElementType
        {
          AlkaliMetal,
          AlkalineEarthMetal,
          Lanthanide,
          Actinide,
          TransitionMetal,
          PostTransitionMetal,
          Metaloid,
          OtherNonMetal,
          Halogen,
          NobleGas,
          Unknown
        }

    }