package domain;

public class Wish {
    private String URL;

    public Wish(String URL) {
        this.URL = URL;
    }

    public String getUrl() {
        return URL;
    }

    public void setUrl(String url) {
        this.URL = url;
    }

    @Override
    public String toString() {
        return "Wish{" +
                "url='" + URL + '\'' +
                '}';
    }
}
