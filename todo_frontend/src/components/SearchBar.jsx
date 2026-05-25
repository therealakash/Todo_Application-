function SearchBar(props) {
    return (
        <div className="search-box">
            <input
                type="text"
                placeholder="Search todos..."
                value={props.search}
                onChange={(e) => props.setSearch(e.target.value)}
            />
            <button onClick={props.onSearch}>Search</button>
            <button onClick={props.onReset}>Reset</button>
        </div>
    );
}

export default SearchBar;