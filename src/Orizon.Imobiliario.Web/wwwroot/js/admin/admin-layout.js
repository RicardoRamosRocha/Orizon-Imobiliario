document.addEventListener("DOMContentLoaded", () => {
    const body = document.body;

    const openButton = document.querySelector("[data-admin-open]");
    const closeButton = document.querySelector("[data-admin-close]");
    const collapseButton = document.querySelector("[data-admin-collapse]");
    const overlay = document.querySelector("[data-admin-overlay]");

    const storageKey = "orizon.admin.sidebar.collapsed";

    const openMenu = () => {
        body.classList.add("admin-menu-open");
    };

    const closeMenu = () => {
        body.classList.remove("admin-menu-open");
    };

    const setCollapsedState = (collapsed) => {
        body.classList.toggle("admin-sidebar-collapsed", collapsed);

        collapseButton?.setAttribute(
            "aria-label",
            collapsed ? "Expandir menu" : "Recolher menu"
        );

        collapseButton?.setAttribute(
            "title",
            collapsed ? "Expandir menu" : "Recolher menu"
        );
    };

    const savedState = localStorage.getItem(storageKey);

    if (savedState === "true" && window.innerWidth > 991) {
        setCollapsedState(true);
    }

    collapseButton?.addEventListener("click", () => {
        if (window.innerWidth <= 991) {
            closeMenu();
            return;
        }

        const collapsed = !body.classList.contains(
            "admin-sidebar-collapsed"
        );

        setCollapsedState(collapsed);
        localStorage.setItem(storageKey, String(collapsed));
    });

    openButton?.addEventListener("click", openMenu);
    closeButton?.addEventListener("click", closeMenu);
    overlay?.addEventListener("click", closeMenu);

    window.addEventListener("resize", () => {
        if (window.innerWidth > 991) {
            closeMenu();

            const collapsed =
                localStorage.getItem(storageKey) === "true";

            setCollapsedState(collapsed);
        } else {
            body.classList.remove("admin-sidebar-collapsed");
        }
    });
});
