﻿using Langs.Data.Objects.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Langs.Data.Objects
{
    [DebuggerDisplay("Def: Lang: {Language.Name} Text: {Text}")]
    public class Definition : BaseObject, IHaveID, IDisplayText, IListableElement
    {
        public Definition() { }
        public Definition(string text, Language language, string description = "")
        {
            Text = text;
            Language = language;
            Description = description;
        }

        [Required]
        public virtual string Text { get; set; }
        [Required]
        public virtual Language Language { get; set; }

        public virtual string Description { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }

        // -----------------
        string IDisplayText.DisplayText => Text;
    }
}
