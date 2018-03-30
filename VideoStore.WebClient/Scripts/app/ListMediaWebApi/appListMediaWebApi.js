var vm = new Vue({
    el: "#app",
    data: {
        mediaList: []
    },
    mounted() {
        this.getItems();
    },
    methods: {
        getItems() {
            axios.get("/ListMediaData/GetAllMedia").then(response => {
                this.mediaList = response.data;
            });
        },
        getDetailsHref(id) {
            return "/Media/Details?mediaId=" + id;
        }
    },
    computed: {
    }
});