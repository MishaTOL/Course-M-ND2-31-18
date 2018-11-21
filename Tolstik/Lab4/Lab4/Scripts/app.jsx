
class Tweet extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.tweet };
    }
    render() {
        return <div>
            <p><b>{this.state.data.Content}</b></p>
            <p>{moment(this.state.data.DateOfCreation).format('MMMM Do YYYY, h:mm:ss a')}</p>
        </div>;
    }
}

class TweetForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = { content: ""};

        this.onSubmit = this.onSubmit.bind(this);
        this.onContentChange = this.onContentChange.bind(this);
    }
    onContentChange(e) {
        this.setState({ content: e.target.value });
    }
    onSubmit(e) {
        e.preventDefault();
        var content = this.state.content.trim();
        if (!content) {
            return;
        }
        this.props.onTweetSubmit({ content: content });
        this.setState({ content: "" });
        location.reload();
    }
    render() {
        return (
            <form onSubmit={this.onSubmit}>
                <p>
                    <input class="form-control " type="text"
                        placeholder="Что нового?"
                        value={this.state.content}
                        onChange={this.onContentChange}
                        maxLength = "240" />
                </p>
                <input type="submit" value="Сохранить" />
            </form>
        );
    }
}

class TweetsList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { tweets: [] };

        this.onAddTweet = this.onAddTweet.bind(this);
    }

    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.getUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ tweets: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }

    onAddTweet(tweet) {
        if (tweet) {

            var data = new FormData();
            data.append("content", tweet.content);

            var xhr = new XMLHttpRequest();
            xhr.open("post", this.props.postUrl, true);
            xhr.onload = function () {
                if (xhr.status == 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    render() {

        return <div>
            <TweetForm onTweetSubmit={this.onAddTweet} />
            <div>
                {
                    this.state.tweets.map(function (tweet) {

                        return <Tweet key={tweet.Id} tweet={tweet} />
                    })
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <TweetsList getUrl="/Tweet/TweetsList" postUrl="/Tweet/CreateTweet" />,
    document.getElementById("content")
);