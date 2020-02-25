﻿@ModelType lab_47_mvc_framework_demo.lab_47_mvc_framework_demo.User
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>User</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Category.CategoryName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Category.CategoryName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserName)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DateOfBirth)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DateOfBirth)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.isValid)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.isValid)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.UserId }) |
    @Html.ActionLink("Back to List", "Index")
</p>
