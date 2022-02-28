var app = new Vue({
    el: '#app',
    data: {
        price: 0,
        showPrice: true,
        loading: false,
        products: []
    },
    computed: {
        formatPrice: function () {
            return "$" + this.price;
        }
    },
    methods: {
        togglePrice: function () {
            this.showPrice = !this.showPrice;
        },
        log(v) {
            console.log(v);
        },
        getProducts() {
            this.loading = true;

            axios.get('/Admin/products')
                .then(res => {
                    console.log(res);
                    this.products = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        }
    }
});