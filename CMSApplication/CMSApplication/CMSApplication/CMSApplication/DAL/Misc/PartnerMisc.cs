using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSApplication.DAL.Misc
{
	public class PartnerMisc
	{
		private long _pk_miscid;
		public long Pk_miscid
		{
			get { return _pk_miscid; }
			set { _pk_miscid = value; }
		}

		private long _fk_companyid;
		public long Fk_companyid
		{
			get { return _fk_companyid; }
			set { _fk_companyid = value; }
		}

		private string _misc_name;
		public string Misc_name
		{
			get { return _misc_name; }
			set { _misc_name = value; }
		}

		private DateTime? _misc_exp_date;
		public DateTime? Misc_exp_date
		{
			get { return _misc_exp_date; }
			set { _misc_exp_date = value; }
		}

		private string _notes;
		public string Notes
		{
			get { return _notes; }
			set { _notes = value; }
		}

		private bool? _is_active;
		public bool? Is_active
		{
			get { return _is_active; }
			set { _is_active = value; }
		}

		private bool? _is_deleted;
		public bool? Is_deleted
		{
			get { return _is_deleted; }
			set { _is_deleted = value; }
		}

		private long _fk_created_by;
		public long Fk_created_by
		{
			get { return _fk_created_by; }
			set { _fk_created_by = value; }
		}

		private long _fk_modified_by;
		public long Fk_modified_by
		{
			get { return _fk_modified_by; }
			set { _fk_modified_by = value; }
		}

		private DateTime _created_date;
		public DateTime Created_date
		{
			get { return _created_date; }
			set { _created_date = value; }
		}

		private DateTime _modified_date;
		public DateTime Modified_date
		{
			get { return _modified_date; }
			set { _modified_date = value; }
		}

	}
}