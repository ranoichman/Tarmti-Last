class userMNG {

    constructor(userID, name, rank, assocAmount, active) {
        this.id = userID;
        this.name = name;
        this.rank = rank;
        this.assocAmount = assocAmount //כמות העמותות שהמשתמש מורשה גישה אליהן
        this.active = active == true ? "פעיל" : " לא פעיל";
    } //ctor end

    display_info()
    {
        var $pId = $("<p>").text("ת.ז: " + this.id);
        var $pName = $("<p>").text(" שם: " + this.name);
        var $pPermit = $("<p>").text("מורשה גישה ל-" + this.assocAmount + " עמותות");
        var $info = $("<div>").append($pId,$pName,$pPermit);

        //var $info = "ת.ז: " + this.id
        //    + " שם: " + this.name
        //    + "מורשה גישה ל-" + this.assocAmount + " עמותות";
        return $info;
    }


}// class end