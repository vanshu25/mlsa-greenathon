import './SearchBox.scss';

const SearchBox = () => {
  return (
    <div className="search-box">
      <input type="text" name="searchBox" id="searchBox" placeholder="Search a business..."/>
    </div>
  );
};

export default SearchBox;