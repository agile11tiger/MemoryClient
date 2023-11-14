//Два меню админа не могут быть открыты одновременно
class AdminMenu {
    constructor() {
        this.runEventListeners();
    }
    runEventListeners() {
        this.hideAdminMenuBox = this.hideAdminMenuBox.bind(this);
        document.addEventListener("mouseup", this.hideAdminMenuBox, false);
        this.showAdminMenuBox = this.showAdminMenuBox.bind(this);
        document.addEventListener("mouseup", this.showAdminMenuBox, false);
    }
    showAdminMenuBox(e) {
        let btn = e.target;
        if (btn.className == "adminMenu__btn") {
            this.adminMenuToggle = btn.previousElementSibling;
        }
    }
    hideAdminMenuBox(e) {
        var _a;
        if (this.adminMenuToggle != null && ((_a = e.target) === null || _a === void 0 ? void 0 : _a.htmlFor) != this.adminMenuToggle.id) {
            this.adminMenuToggle.checked = false;
        }
    }
}
var adminMenu = new AdminMenu();
window.events = {
    clickElement: function (element) {
        element.click();
    }
}
//Два контекстных меню не могут быть открыты одновременно
class ContextMenuEvents {
    constructor() {
        this.runEventListeners();
    }
    runEventListeners() {
        this.hideContextMenuBox = this.hideContextMenuBox.bind(this);
        //true необходимо для того, чтобы наверняка вначале скрывалось предыдущее меню, а потом показывалось новое
        document.addEventListener("mouseup", this.hideContextMenuBox, false);
        this.showContextMenuBox = this.showContextMenuBox.bind(this);
        document.addEventListener("mouseup", this.showContextMenuBox, false);
    }
    showContextMenuBox(e) {
        let btn = e.target;
        if (btn.className == "contextMenu__btn") {
            this.contextMenuToggle = btn.previousElementSibling;
        }
    }
    hideContextMenuBox(e) {
        var _a;
        if (this.contextMenuToggle != null && ((_a = e.target) === null || _a === void 0 ? void 0 : _a.htmlFor) != this.contextMenuToggle.id) {
            this.contextMenuToggle.checked = false;
        }
    }
    //private hideContextMenuBox(e: Event): void {

    //    if (this.contextMenuToggle != null && (e.target as HTMLLabelElement)?.htmlFor != this.contextMenuToggle.id) {
    //        this.contextMenuToggle.checked = false;
    //    }
    //}
}
var contextMenuEvents = new ContextMenuEvents();