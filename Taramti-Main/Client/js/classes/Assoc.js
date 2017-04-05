class assocMNG {

    constructor(code, name, tags) {
        this.code = code;
        this.name = name;
        this.tags = tags;
        this.donations = 0;
    } //ctor end

    setDonation(amount) {
        this.donations = amount;
    }


    //display_info() {
    //    var $pId = $("<p>").text("ת.ז: " + this.id);
    //    var $pName = $("<p>").text(" שם: " + this.name);
    //    var $pPermit = $("<p>").text("מורשה גישה ל-" + this.assocAmount + " עמותות");
    //    var $info = $("<div>").append($pId, $pName, $pPermit);

    //    //var $info = "ת.ז: " + this.id
    //    //    + " שם: " + this.name
    //    //    + "מורשה גישה ל-" + this.assocAmount + " עמותות";
    //    return $info;
    //}


}// class end