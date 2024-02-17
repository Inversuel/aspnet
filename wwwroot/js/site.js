// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".add-email-btn").on("click", function () {
  const id = $(this).data("id");
  console.log("click add emial btn");
  $(`#add-email-modal-${id}`).removeClass("hidden");
});

$(".add-email-submit").on("click", function () {
  const id = $(this).data("id");
  console.log("click submit");
  $(`#add-email-modal-${id}`).addClass("hidden");
});

$(`.add-email-x`).on("click", function () {
  const id = $(this).data("id");
  console.log("click x");
  $(`#add-email-modal-${id}`).addClass("hidden");
});
