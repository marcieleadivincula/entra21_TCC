
function populateUFs() {
    const ufSelect = document.querySelector("[name=uf]");

    fetch("https://servicodados.ibge.gov.br/api/v1/localidades/estados")
        .then(resp => resp.json())
        .then(states => {
            for (const state of states) {
                ufSelect.innerHTML += `<option value="${state.id}">${state.nome}</option>`;
            }
        });
}

populateUFs();

function getCities(event) {
    const citySelect = document.querySelector("[name=city]");
    const stateInput = document.querySelector("[name=state]");
    const ufValue = event.target.value;

    const indexOfSelectedState = event.target.selectedIndex;

    stateInput.value = event.target.options[indexOfSelectedState].text;

    const url = `https://servicodados.ibge.gov.br/api/v1/localidades/estados/${ufValue}/municipios`;

    citySelect.innerHTML = `<option>Selecione a cidade</option>`;
    citySelect.disabled = true;

    fetch(url)
        .then(resp => resp.json())
        .then(cities => {
            for (const city of cities) {
                citySelect.innerHTML += `<option value="${city.id}">${city.nome}</option>`;
            }

            citySelect.disabled = false;
        });
}

document.querySelector("[name=uf]").addEventListener("change", getCities);

//Itens de coleta
//pefar todos os li's
const itemsToCollect = document.querySelectorAll(".items-grid li");

for (const item of itemsToCollect) {
    item.addEventListener("click", handleSelectedItem);
}

let selectedItems = [2, 3];

function handleSelectedItem(event) {
    const itemLi = event.target;

    // add or remove uma class com JS
    //Com o toggle ele verifica o elemento, se existe ele remove, se não existir ele adiciona
    itemLi.classList.toggle("selected");

    const itemId = itemLi.dataset.id;

    //verificar se existem items selecionados, se sim pegar os itens selecionados
    const alreadySelected = selectedItems.findIndex(item => {
        return item === itemId; //isso será true ou false
    });

    //se já estiver selecionado,
    //alreadySelected >= 0 ou alreadySelected != -1
    if (alreadySelected >= 0) {
        //tirar da seleção
        const filteredItems = selectedItems.filter(item => {
            //quando o return for false é o momento que deverá ser removido do array
            return item !== itemId; //false
        });

        console.log(filteredItems);
    }
    //se não estiver selecionado, adicionar à seleção

    //atualizar o campo escondido com os itens selecionados
}



//Dessa forma está detalhada, mas em cima está simplificada
// const alreadySelected = selectedItems.findIndex(function (item) {
//     const itemFound = item === itemId;
//     return itemFound;
// });

// const filteredItems = selectedItems.filter((item) => {
//   const itemsIsDifferent = item !== itemId; //false
//   return itemsIsDifferent;
// });

//fetch("https://servicodados.ibge.gov.br/api/v1/localidades/estados").then(function(res) { return res.json()}).then(function(data){console.log(data)})
//resp => resp.json() mesmo que function(res) { return res.json()
