    $(document).ready(function () {       
        updateList();
        $("#addItem").click(addItem);        
    });

    function updateList() {
        startOperation();
        $.ajax({
            url: URL,
            contentType: "application/json",
            type: "GET",

            processData: false,
            headers: {
                "accept": "application/json",
            },
            success: function (data) {
                $("#list").empty();
                let items = data;
                for (let i = 0; i < items.length; i++) {
                    let checkbox = document.createElement("input")
                    checkbox.id = items[i].id;
                    checkbox.type = "checkbox";
                    checkbox.name = checkbox.id;
                    checkbox.checked = items[i].checkmark;

                    let label = document.createElement("label");
                    label.innerHTML = items[i].name;


                    
                    $("#list").append(label);
                    $(label).prepend(checkbox);
                    $("#list").append(document.createElement("br"));

                    
                }
                $("input[type='checkbox']").change(updateElement);
                stopOperation();
            },
            error: logError           
        });
    }

    function updateElement() {
        startOperation();
        var item = new Object();
        item.name = this.parentNode.textContent;
        item.checkmark = this.checked;

        $.ajax({
            url: URL + "/" + getId(this.id),
            contentType: "application/json",
            type: "PUT",

            processData: false,
            data: JSON.stringify(item),
            success: function () {
                stopOperation();
            },
            error: logError
        });

        function getId(id) {
            return id.substring(0);
        }
    }

    function addItem() {
        
        let itemName = prompt("Hvad hedder det element, du vil tilføje?");
        if (itemName === undefined) {
            return;
        }
        startOperation();
        var item= new Object();
        item.name = itemName;
        item.checkmark = false;

        $.ajax({
            url: URL,
            contentType: "application/json",
            type: "POST",

            headers: {
                "accept": "application/json",
            },
            data: JSON.stringify(item),
            
            success: function () {
                updateList();
            },
            error: logError
        });
    }


    function logError(xhr, textStatus, errorThrown) {
        stopOperation();
        console.log('Error in Operation');
        console.log(xhr);
        console.log(textStatus);
        console.log(errorThrown);
    }

    function stopOperation() {
        $(".sk-fading-circle").hide();
    }

    function startOperation() {
        $(".sk-fading-circle").show();
    }