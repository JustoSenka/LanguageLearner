﻿using LangData.Objects.Base;
using LanguageLearner.Models.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

public static class ExtensionMethods
{
    public static List<SelectListItem> SelectListItems(this IEnumerable<IListableElement> listable)
    {
        return listable?.Select(ToListItem).ToList();
    }

    public static SelectListItem ToListItem(this IListableElement listable)
    {
        return new SelectListItem(listable.ID.ToString(), listable.DisplayText);
    }

    public static IEnumerable<TableElement> SelectTableElements(this IEnumerable<IListableElement> listable)
    {
        return listable?.Select(ToTableElement);
    }

    public static TableElement ToTableElement(this IListableElement listable)
    {
        return TableElement.Link(listable.ID, listable.DisplayText);
    }
}
