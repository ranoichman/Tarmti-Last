
        


        var SignUp = React.createClass({
            
            edit: function(){
                this.setState({editing})
            },
                
            render: function () {
                return (
                <div className="row">
                    <div className="col-xs-pull-6" dir="rtl">
                        <div style={{ width: '50%' }}>
                        <div className="rect">
                        <h3 className="text-center">15:20</h3>
                    </div>
                    <h4 className="text-center">כותרת</h4>
                    <p className="descPar">קצת מלל וכל מיני דברים שבא לי לכתוב וכן הנה עוד קצת דברים ותכף יהיו כאן גם תמונות וזה בסך הכל תיאור של מוצר</p>
                </div>
            </div>
            <div className="col-xs-6">
                <img ref="disIMG" src={this.state.imgArr[this.state.index]} />
            </div>
        </div>
        );
}
});

ReactDOM.render(
<Auction />,
document.getElementById('auctionsPH'));