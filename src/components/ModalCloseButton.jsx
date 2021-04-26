import './ModalCloseButton.scss';

import Close from '../assets/icons/close.svg';

const ModalCloseButton = (props = { onModalClose: () => { } }) => {
  return (
    <button className="close-btn" onClick={props.onModalClose}>
      <img alt="Close" src={Close} />
    </button>
  )
}

export default ModalCloseButton;