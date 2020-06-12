var app = new Vue({
    el: '#app',
    data: {
        
        newUser: {
            //userId: 0,
            UserName:"Ad",
            Email: "Mail",
            Sifre: "password"
        }
    },
    mounted() {
        //this.getStock();
    },
    computed: {
    }
    ,

    methods: {
        addUser() {
            this.loading = true;
            console.log(typeof (this.newUser.userId));
            //    this.parseInt(this.newStock.qty);
            //if (typeof (this.newStock.qty) != typeof (1)) {
            //    alert("Quantity should be number");
            //}
            //else {
            axios.post('/api/User/SignInPost', this.newUser).
                    then(res => {
                        console.log(res);                        
                    })
                    .catch(err => {
                        console.log(err);
                    })
                    .then(() => {
                        this.loading = false;
                    });
            //}
        },
    }
});

Vue.config.devtools = true;