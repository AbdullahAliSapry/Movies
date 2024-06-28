const ButtonModel = document.querySelector(".ModelOpen");
const ButtonModelCansel = document.querySelector(".closeBtn");
const ModelForm = document.querySelector(".ModalForm");
ButtonModel.addEventListener("click", () => {
    ModelForm.classList.remove("hidden");
})

ButtonModelCansel.addEventListener("click", () => {

    ModelForm.classList.add("hidden");
})