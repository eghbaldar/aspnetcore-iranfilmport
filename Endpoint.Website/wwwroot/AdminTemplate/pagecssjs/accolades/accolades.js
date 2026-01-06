function openSearchModal() {
    $("#ModalEditSearchFilm").modal("show");
}
function goToAccolade() {
    if (!isEmptyKing($("#selectSearchFilms").val())) {
        window.location = `/admin/addAccolade/${$("#selectSearchFilms").val()}`;
    }
}
// dynamic search on <select>
document.addEventListener('DOMContentLoaded', function () {
    const selectFilms = document.getElementById('selectSearchFilms');

    // Create a search input
    const searchInput = document.createElement('input');
    searchInput.type = 'text';
    searchInput.className = 'form-control search';
    searchInput.placeholder = 'جستجوی اثر ...';
    searchInput.style.marginBottom = '5px';

    // Insert search input before the select
    selectFilms.parentNode.insertBefore(searchInput, selectFilms);

    // Store original options
    const originalOptions = Array.from(selectFilms.options);

    // Filter function
    function filterOptions(searchTerm) {
        // Clear current options except the first disabled one
        while (selectFilms.options.length > 1) {
            selectFilms.remove(1);
        }

        if (!searchTerm) {
            // Restore all options
            originalOptions.forEach(option => {
                if (option.value) {
                    selectFilms.appendChild(option.cloneNode(true));
                }
            });
            return;
        }

        const term = searchTerm.toLowerCase();
        originalOptions.forEach(option => {
            if (option.textContent && option.textContent.toLowerCase().includes(term)) {
                selectFilms.appendChild(option.cloneNode(true));
            }
        });
    }

    // Add event listener for search
    searchInput.addEventListener('input', function () {
        filterOptions(this.value);
        if (isEmptyKing($("#selectFilms").val())) {
            $("#content").prop("hidden", true);
        }
        else {
            $("#content").prop("hidden", false);
        }
    });

    // Add event listener for key navigation
    searchInput.addEventListener('keydown', function (e) {
        if (e.key === 'ArrowDown') {
            e.preventDefault();
            selectFilms.focus();
            if (selectFilms.options.length > 1) {
                selectFilms.selectedIndex = 1;
            }
        }
    });
});