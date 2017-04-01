class userMNG {

    constructor(userID, name, rank, assocAmount, active) {
        this.id = userID;
        this.name = name;
        this.rank = rank;
        this.assocAmount = assocAmount //כמות העמותות שהמשתמש מורשה גישה אליהן
        this.active = active;
    } //ctor end



    changeActive() {


    }

    static getAll() {
        $.ajax({
            dataType: "json",
            url: "/../AdminWebService.asmx/GetAllUsers",
            contentType: "application/json; charset=utf-8",
            type: "POST",
            data: JSON.stringify({}),
            success: function (data) {
                return data.d;
            },
            error: function (err) {
                return err;
            }
        });
    }



}// class end