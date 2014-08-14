<?php

class c_@SINGULARNAME@
{
	/* declare all the fields in the table */
	
	var $m@SINGULARNAME@id;
	£var $m@FIELD@;
	£var $m@LASTFIELD@;
	
~	£var $orig@FIELD@;
	£var $orig@LASTFIELD@ As @LASTFIELDTYPE@;
~
	
	function retrieve ($@SINGULARNAME@id) {
	
		global $db;

		$my_@SINGULARNAME@ = $db->get_row('SELECT * FROM @TABLENAME@ WHERE @SINGULARNAME@ = ' . $@SINGULARNAME@id );
		
		if (is_null($my_@SINGULARNAME@)) {
			return null;
		}
		else {
			$this->@SINGULARNAME@id = $my_@SINGULARNAME@->@SINGULARNAME@id;
			£$this->@FIELD@ = $my_@SINGULARNAME@->@FIELD@;
			£$this->@LASTFIELD@ = $my_@SINGULARNAME@->@LASTFIELD@;
			return $this->@SINGULARNAME@id;
		}

	}

	function retrieve_by_employeeref ($employeeref) {

		global $db;

		$my_employee = $db->get_row("SELECT employeeid FROM kj_employees WHERE employeeref = '" . $employeeref . "'" );

		if (is_null($my_employee)) {
			return null;
		}
		else {
			retrieve($my_employee->employeeid);
		}
	}
	
		
		
	function insert() {
	
		global $db;

		$strSQL = " INSERT INTO @TABLENAME@ ("
		£$strSQL .= " @FIELD@, ";
		£$strSQL .= " @LASTFIELD@)";
		$strSQL .= " VALUES (";
		£$strSQL .= "	@PHPNULL@(" . $this->@FIELD@ . "), ";
		£$strSQL .= "	@LASTPHPNULL@(" . $this->@LASTFIELD@ . ") ";
		return $db->query($strSQL);
	}
	
	function datesql(value) {
		$theday=strtok(value,"/");
		$themonth=strtok("/");
		$theyear=strtok("/");
		$strSQL .= " '" . $theyear . "-" . $themonth . "-" . $theday . "', ";
		return $strSQL;
	}
	
	function nullsqldate(value) {
		return nullsql(datesql(value));
	}
	
	function nullsql(value) {
		return iif(value==null,"NULL","'" . value . "'");
	}
	
	function update() {
	
		global $db;
		$strSQL = " UPDATE @TABLENAME@ ";
		£$strSQL .= " SET @FIELD@ = @PHPNULL@(" . $this->@FIELD@ . "), ";
		£$strSQL .= " SET @FIELD@ = @LASTPHPNULL@(" . $this->@LASTFIELD@ . ") ";
		$strSQL .= " WHERE @SINGULARNAME@id = $this->@SINGULARNAME@id ";
	
		return $db->query($strSQL);
	}


/*	
	function delete() {
	
	}
*/

}
?>
